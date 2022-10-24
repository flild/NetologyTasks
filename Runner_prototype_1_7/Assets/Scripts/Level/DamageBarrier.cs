using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageBarrier : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth health))
        {
            health.Hit(0.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth health))
        {
            health.Hit(0.5f);
        }
    }
}
