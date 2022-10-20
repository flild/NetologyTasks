using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForwardMove : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _playerSpeed = 5f;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _rb.velocity += Vector3.forward * _playerSpeed * Time.fixedDeltaTime;
    }

}
