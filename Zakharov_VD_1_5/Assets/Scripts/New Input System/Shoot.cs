using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEngine.InputSystem.InputAction;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;

    private PlayerConrols _input;
    private GameObject _currentBullet;
    private void Awake()
    {
        _input = new PlayerConrols();
    }
    private void OnEnable()
    {
        _input.Enable();
        _input.PlayerKeyboardMap.Shoot.performed += OnShoot;

    }

    private void OnShoot(CallbackContext context)
    {
        Vector3 bulletSpawn = transform.position + new Vector3(0, 0, 1);
        _currentBullet = Instantiate(_bullet, bulletSpawn, Quaternion.Euler(0, 0, 90));
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.PlayerKeyboardMap.Shoot.performed -= OnShoot;
    }
}
