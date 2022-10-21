using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BasePlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] protected float _sideMoveSpeed = 5;
    [SerializeField] private float _jumpForce = 5;

    private bool _isOnGround = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    protected void SideMove(float direction)
    {
        _rb.velocity += Vector3.right * direction * _sideMoveSpeed* Time.fixedDeltaTime;
    }

    protected void Jump()
    {
        Debug.Log(_isOnGround);
        if (_isOnGround)
        {
            _isOnGround = false;
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Force);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        _isOnGround = true;
    }
}
