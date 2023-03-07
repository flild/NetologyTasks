using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] float _damage;
        private void OnCollisionEnter(Collision collision)
        {
            if (TryGetComponent<Warrior>(out Warrior warrior))
            {
                warrior.TakeDamage(_damage);
            }
    }
    }
}

