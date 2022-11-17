using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    private PlayerController _input;
    private Rigidbody _rb;
    private float _cameraRotationX;
    private float _cameraRotationY;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float HorizontalSensitivity = 30.0f;
    [SerializeField] private float VerticalSensitivity = 30.0f;


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
        //поворот камеры за мышкой
        _cameraRotationX = _input.PlayerMap.ViewX.ReadValue<float>()* HorizontalSensitivity;
        _cameraRotationY = _input.PlayerMap.ViewY.ReadValue<float>()* -VerticalSensitivity;
        transform.localEulerAngles += new Vector3(_cameraRotationY, _cameraRotationX, 0) * Time.deltaTime;
    }
    private void Move(Vector2 Value)
    {
        Vector3 mover =  new Vector3(Value.x, 0 , Value.y);
        _rb.velocity = mover * _speed * Time.fixedDeltaTime;
    }

    private void OnShoot(CallbackContext cotext)
    {

    }

    private void OnJump(CallbackContext cotext)
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Force);
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.PlayerMap.Shoot.performed -= OnShoot;
        _input.PlayerMap.Jump.performed -= OnJump;
    }
}


