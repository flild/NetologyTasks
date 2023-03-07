using UnityEngine;



namespace Ziggurat
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent (typeof(FieldOfView))]
    public class Warrior : MonoBehaviour, IWarrior
    {
        //stats
        public WarriorColor color { get; set; }
        public float health { get; set; }
        public float speed { get; set; }
        public float slowAttackDamage { get; set; }
        public float fastAttackDamage { get; set; }
        public float missChance { get; set; }
        public float slowAttackChance { get; set; }
        public float fastAttackChance { get; set; }
        public float maxHealth { get; private set; }

        private Rigidbody _rb;
        private Ziggurat _ziggurat;
        private WarriorMovment _movement;
        private UnitEnvironment _animator;
        private ParametersCalibration _AIMove;
        private FieldOfView _FOV;
        private Attacks _attacks;
        private CanvasHealth _canvasHealth;
        private UIManager _UIManager;
        private bool _isMoving;



        private void Start()
        {
            Initialisation();

        }
        private void Initialisation()
        {
            _ziggurat = GetComponentInParent<Ziggurat>();
            _movement = GetComponent<WarriorMovment>();
            _animator = GetComponent<UnitEnvironment>();
            _AIMove = GetComponent<ParametersCalibration>();
            _FOV = GetComponent<FieldOfView>();
            _attacks = GetComponent<Attacks>();
            _canvasHealth = GetComponentInChildren<CanvasHealth>();
            _UIManager = FindObjectOfType<UIManager>();
            //stats
            color = _ziggurat.color;
            health = _ziggurat.GetUnitInfo(UnitInfoType.health);
            speed = _ziggurat.GetUnitInfo(UnitInfoType.speed);
            slowAttackDamage = _ziggurat.GetUnitInfo(UnitInfoType.slowAttackDamage);
            fastAttackDamage = _ziggurat.GetUnitInfo(UnitInfoType.fastAttackDamage);
            missChance = _ziggurat.GetUnitInfo(UnitInfoType.missChance);
            slowAttackChance = _ziggurat.GetUnitInfo(UnitInfoType.slowAttackChance);
            fastAttackChance = _ziggurat.GetUnitInfo(UnitInfoType.fastAttackChance);
            maxHealth = health;
            //value
            _isMoving = false;

            //events
            _UIManager.KillAll += OnKillAll;
            _movement.EndMoving += OnEndMove;
        }
        private void Update()
        {
            if (!_isMoving)
            { 
                ActionCheck();
            }
            //тут хз, если проверку убрать, то войнов начнет дико колбасить, а если ждать конца анимации, то они довольно редко проверяют кто есть рядом.
        }
        public void ActionCheck()
        { 
            ActionType action = _AIMove.GetActionType();
            Debug.Log(action);
            _isMoving = true;
            switch(action)
            {
                case ActionType.Attack:
                    Attack();
                    break;
                case ActionType.Fear:
                    _movement.fear();
                    break;
                case ActionType.Wandering:
                    _movement.wandering();
                    break;
                case ActionType.MoveTo:
                    if(_FOV.HasTargets())
                    {
                        _movement.Move();
                        break;
                    }
                    else
                    {
                        _movement.wandering();
                        break;
                    }
                    
            }

        }
        private void Attack()
        {
            AttackType attack = _AIMove.GetAttackType();

            switch(attack)
            {
                case AttackType.SlowAttack:
                    _attacks.SlowAttack(_FOV.GetNearestTarget());
                    break;
                case AttackType.FastAttack:
                    _attacks.FastAttack(_FOV.GetNearestTarget());
                    break;
            }
        }
        public void TakeDamage(float damage)
        {
            health -= damage;
            _canvasHealth.TakeDamage(damage);
            if (health < 0)
                Die();

        }

        public void Die()
        {
            _animator.Moving(0);
            _animator.StartAnimation("Die");
            _ziggurat.UnitDie();
        }

        public void OnKillAll()
        {
            Die();
        }
        private void  OnEndMove()
        {
            _isMoving = false;
        }
        private void OnDisable()
        {
            _UIManager.KillAll -= OnKillAll;
            _movement.EndMoving -= OnEndMove;
        }

    }
}

 