using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class RotateQE : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private PlayerConrols _input;
    private bool isRotate = false;
    private void Awake()
    {
        _input = new PlayerConrols();
    }
    private void OnEnable()
    {
        _input.Enable();
        _input.PlayerKeyboardMap.Rotation.performed += OnRotate;
        _input.PlayerKeyboardMap.Rotation.canceled += OnStop;

    }

    private void OnRotate(CallbackContext context)
    {
        isRotate = true;
        StartCoroutine(Rotate(context.ReadValue<float>()));
    }

    private void OnStop(CallbackContext context)
    {
        isRotate = false;
    }

    private IEnumerator Rotate(float side)
    {
        while (isRotate)
        {
            transform.eulerAngles += new Vector3(0, side,0) * Time.deltaTime * _moveSpeed;
            yield return new WaitForFixedUpdate();
        }
    }
    private void OnDisable()
    {
        _input.PlayerKeyboardMap.Movement.started -= OnRotate;
        _input.PlayerKeyboardMap.Movement.canceled -= OnStop;
        _input.Disable();
    }
}
