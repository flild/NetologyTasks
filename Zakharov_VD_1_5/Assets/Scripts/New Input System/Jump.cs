using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Jump : MonoBehaviour
{

    [SerializeField] private float _jumpForce;

    private PlayerConrols _input;
    private bool _isOnGround=true;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _input = new PlayerConrols();
    }
    private void OnEnable()
    {
        _input.Enable();
        _input.PlayerKeyboardMap.Jump.performed += OnJump;

    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        _isOnGround = true;
    }
    private void OnJump(CallbackContext context)
    {
        if (_isOnGround)
        {
            _isOnGround = false;
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Force);
        }
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.PlayerKeyboardMap.Jump.performed -= OnJump;
    }
}
