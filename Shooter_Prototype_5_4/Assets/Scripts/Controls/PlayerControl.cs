using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    private PlayerController _input;
    private Rigidbody _rb;
    private bool _isOnGround = true;

    public delegate void MethodContainer();
    public event MethodContainer onShootEvent;


    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;



    private void Awake()
    {
        _input = new PlayerController(); 
        
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.PlayerMap.Shoot.performed += OnShoot;
        _input.PlayerMap.Jump.performed += OnJump;
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

   

    private void FixedUpdate()
    {
        Move(_input.PlayerMap.Move.ReadValue<Vector2>());
    }

    private void Update()
    {
        

    }
    private void Move(Vector2 Value)
    {
        Vector3 mover = Value.y * transform.forward + Value.x * transform.right;
        _rb.AddForce( mover.normalized * _speed, ForceMode.Force);
    }

    private void OnShoot(CallbackContext context)
    {
            onShootEvent();
    }

    private void OnJump(CallbackContext context)
    {
        if (_isOnGround)
        {
            _rb.AddForce(transform.up * _jumpForce, ForceMode.Force);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        _isOnGround = true;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.PlayerMap.Shoot.performed -= OnShoot;
        _input.PlayerMap.Jump.performed -= OnJump;
    }
}


