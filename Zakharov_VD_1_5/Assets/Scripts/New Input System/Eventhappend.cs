using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Eventhappend : MonoBehaviour
{
    private PlayerConrols _input;
    private void Awake()
    {
        _input = new PlayerConrols();
    }
    private void OnEnable()
    {
        _input.Enable();
        _input.PlayerKeyboardMap.Event.performed += OnEvent;

    }

    private void OnEvent(CallbackContext context)
    {
        Debug.Log(context.control);
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.PlayerKeyboardMap.Event.performed -= OnEvent;
    }
}
