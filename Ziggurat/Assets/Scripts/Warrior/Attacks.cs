using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class Attacks : MonoBehaviour
    {
        private UnitEnvironment _animator;
        private void Start()
        {
            _animator = GetComponent<UnitEnvironment>();
        }
        public void SlowAttack(Transform target)
        {
            _animator.Moving(0);
            transform.LookAt(target);
            _animator.StartAnimation("Strong");
        }

        public void FastAttack(Transform target)
        {
            _animator.Moving(0);
            transform.LookAt(target);
            _animator.StartAnimation("Fast");
        }


    }
}

