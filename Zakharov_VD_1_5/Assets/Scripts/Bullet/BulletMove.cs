using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float _timeToDeath = 5f;
    private float _moveSpeed = 3f;
    private void OnEnable()
    {
        StartCoroutine(MoveToDeath());
    }

    private IEnumerator MoveToDeath()
    {
        while (_timeToDeath > 0)
        {
            transform.position += transform.forward * Time.deltaTime * _moveSpeed;
            _timeToDeath-= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
            Destroy(gameObject);
            
        yield return null;
    }
}
