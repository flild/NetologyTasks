using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private bool isMove = false;

    private PlayerConrols _input;

    private void Awake()
    {
        _input = new PlayerConrols();
    }
    private void OnEnable()
    {
        _input.Enable();
        _input.PlayerKeyboardMap.Movement.started += OnMove;
        _input.PlayerKeyboardMap.Movement.canceled += OnStop;
    }

    private void OnMove(CallbackContext context)
    {
        isMove = true;
        StartCoroutine(Move(context.ReadValue<Vector2>()));

    }

    private void OnStop(CallbackContext context)
    {
        isMove = false;
    }

    private IEnumerator Move(Vector2 direction)
    {
        while (isMove)
        {
            transform.position += new Vector3(direction.x, 0, direction.y) * Time.deltaTime * _moveSpeed;
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnDisable()
    {
        _input.PlayerKeyboardMap.Movement.started -= OnMove;
        _input.PlayerKeyboardMap.Movement.canceled -= OnStop;
        _input.Disable();
    }
}
