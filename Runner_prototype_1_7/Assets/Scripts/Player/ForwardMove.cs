using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForwardMove : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _playerSpeed;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(MoveForward());
    }
    private IEnumerator MoveForward()
    {
        while (true)
        {
            _rb.velocity += Vector3.forward * _playerSpeed*Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

}
