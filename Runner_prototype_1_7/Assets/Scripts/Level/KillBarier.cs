using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBarier : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth health))
        {
            health.Kill();
        }
    }
}
