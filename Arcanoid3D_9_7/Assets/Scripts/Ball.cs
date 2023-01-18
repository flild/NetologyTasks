using UnityEngine;
using UnityEditor;
using static UnityEngine.InputSystem.InputAction;
namespace Arcanoid
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private LevelSpawn _levelManager;
        [SerializeField] private float _health;
        [SerializeField] private float _startSpeed;
        [SerializeField] private float _maxBallSpeed;

        private BallSpawnPoint _freezePoint;
        private Platform _currentPlatform;
        private bool isFreezeToShoot;
        private PlayersConrol _input;
        private Rigidbody _rb;
        private float _ballSpeed;
        private Vector3 _contactPosition;
        private Vector3 _lastFrameVelocity;

        private Vector3 _normal;
        private Vector3 _reflection;


        private void Awake()
        {
            _input = new PlayersConrol();
        }
        private void OnEnable()
        {
            _input.Enable();
            _input.Players.Shoot.performed += OnShootBall;
        }
        private void OnDisable()
        {
            _input.Disable();
        }
        private void Start()
        {
            var startPlatform = FindObjectOfType<FirstPlayerControl>();
            isFreezeToShoot = true;
            _ballSpeed = _startSpeed;

            _currentPlatform = startPlatform.GetComponent<Platform>();
            _freezePoint = startPlatform.GetComponentInChildren<BallSpawnPoint>();
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (isFreezeToShoot)
            {
                transform.position = _freezePoint.transform.position;
            }
            _lastFrameVelocity = _rb.velocity;
        }

        private void OnShootBall(CallbackContext context)
        {
            _rb.velocity = _currentPlatform.transform.forward * _ballSpeed;
            isFreezeToShoot = false;

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(_contactPosition, _contactPosition + _normal);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_contactPosition, _contactPosition + _reflection);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + _rb.velocity);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collision");
            _normal = collision.contacts[0].normal;
            _reflection = Vector3.Reflect(_lastFrameVelocity.normalized, _normal);
            _contactPosition = collision.contacts[0].point;
            if (collision.gameObject.TryGetComponent<Block>(out Block _block))
            {
                _ballSpeed = _ballSpeed >= _maxBallSpeed ? _maxBallSpeed : _ballSpeed + 0.5f;
            }
            _rb.velocity = _reflection * _ballSpeed;


        }

        public void FreezeBallToShoot()
        {
            isFreezeToShoot = true;
        }
        public void DestroyLevelBlock(GameObject block)
        {
            _levelManager.ReduceLevelBlocks(block);
        }

        /// <summary>
        /// Устанавливает текущую платформу на которой будет спавниться мяч после смерти или смены уровня
        /// </summary>
        public void SetCurrentPlatform(Platform _platform)
        {
            _currentPlatform = _platform;
            _freezePoint = _platform.GetComponentInChildren<BallSpawnPoint>();
        }
        public void Death()
        {
            isFreezeToShoot = true;
            _ballSpeed = _startSpeed;
            _health -= 1;
            if (_health > 0)
            {
                Debug.Log("Осталось попыток " + _health);
            }
            else
            {
                Debug.Log("Game Over");
                _levelManager.ResetGame();
            }


        }

    }
}
