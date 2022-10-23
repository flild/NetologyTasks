using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WleelMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody _rb;
    private sbyte _direction = 1;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();    
    }
    private void FixedUpdate()
    {
        _rb.velocity += Vector3.right * _moveSpeed * _direction * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        _rb.velocity = Vector3.zero;
        _direction *= -1;
    }
}
