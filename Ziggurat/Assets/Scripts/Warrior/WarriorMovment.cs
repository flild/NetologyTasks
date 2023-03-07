using UnityEngine;
using System.Collections;
using System;

namespace Ziggurat
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent (typeof(Warrior))]
    [RequireComponent(typeof(Transform))]
    public class WarriorMovment : MonoBehaviour
    {
        private Rigidbody _rb;
        private Warrior _warrior;
        private Ziggurat _ziggurat;
        private Vector3 _center;
        private UnitEnvironment _animator;
        private FieldOfView _FOV;


        [SerializeField, Range(0.1f,20f)] 
        private float _wanderinRadius;
        private int _wanderAngel;

        public delegate void MethodContainer();
        public event MethodContainer EndMoving;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _warrior = GetComponent<Warrior>();
            _ziggurat = GetComponentInParent<Ziggurat>();
            _animator = GetComponent<UnitEnvironment>();
            _center = _ziggurat.GetCenterPosition();
            _FOV = GetComponent<FieldOfView>();

            //_animator.OnEndAnimation = 
        }

        public void wandering()
        {
            Vector3 unitDirection = transform.position - _center;
            unitDirection = unitDirection;
            _wanderAngel = UnityEngine.Random.Range(0,30);
            float offset_X = unitDirection.x * Mathf.Cos(_wanderAngel)-unitDirection.z*Mathf.Sin(_wanderAngel);
            float offset_Z = unitDirection.x * Mathf.Sin(_wanderAngel) + unitDirection.z * Mathf.Cos(_wanderAngel);
            //x=x*kosf - y*sinf
            //y=x*sinf + y*kosf
            unitDirection = new Vector3(offset_X,unitDirection.y,offset_Z);
            StartCoroutine(MoveTo(unitDirection));

        }

        private IEnumerator MoveTo(Vector3 target)
        {
            float distanceToTarget;
            target.y = transform.position.y;
            Vector3 offset = target - transform.position;
            distanceToTarget = offset.sqrMagnitude;
            _animator.Moving(1);
            while (distanceToTarget > 3)
            {
                transform.LookAt(target);
                _rb.velocity = offset.normalized * _warrior.speed;
                yield return new WaitForSeconds(0.1f);
                offset = target - transform.position;
                distanceToTarget = offset.sqrMagnitude;
            }
            _rb.velocity = Vector3.zero;
            _animator.Moving(0);
            EndMoving.Invoke();

        }
        public void Move(Transform target = null)
        {
            if(target != null)
            {
                MoveTo(_FOV.GetNearestTarget().position);
            }
            else
            {
                wandering();
            }
        }

        public void fear()
        {
            Transform target = _FOV.GetNearestTarget();
            Vector3 direction = target.position - transform.position;
            StartCoroutine(MoveTo(transform.position - direction));
        }
    }
}
