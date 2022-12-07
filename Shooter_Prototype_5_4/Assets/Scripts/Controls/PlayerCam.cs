using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private float HorizontalSensitivity = 300.0f;
    [SerializeField] private float VerticalSensitivity = 300.0f;
    [SerializeField] private Transform _orientation;

    private PlayerController _input;
    private float _cameraPosX;
    private float _cameraPosY;
    private float _yRotation;
    private float _xRotation;


        private void Update()
    {
        _cameraPosX = Input.GetAxis("Mouse X") * -HorizontalSensitivity * Time.deltaTime;
        _cameraPosY = Input.GetAxis("Mouse Y") * VerticalSensitivity * Time.deltaTime;

        _yRotation += -_cameraPosX;

        _xRotation -= _cameraPosY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        _orientation.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
    }
}
