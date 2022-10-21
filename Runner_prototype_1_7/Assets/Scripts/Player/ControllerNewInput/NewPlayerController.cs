using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.InputSystem.InputAction;


public class NewPlayerController : BasePlayerController
{
    
    private PlayerController _input;

    private void Awake()
    {
        _input = new PlayerController();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.PlayerControlMap.Jump.performed += OnJump;
    }

    private void FixedUpdate()
    {
        SideMove(_input.PlayerControlMap.SideMove.ReadValue<float>());

    }


    private void OnJump(CallbackContext context)
    {
        Jump();
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.PlayerControlMap.Jump.performed -= OnJump;
    }
}
