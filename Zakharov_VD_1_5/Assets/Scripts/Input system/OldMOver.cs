using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OldMOver : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _jumpForce;
    private float _shootTime = 0f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MovePlayer();
        Shoot();
        EventCheck();
        Rotation();
        Jump();

    }

    private void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.position += new Vector3(x, 0, z) * _speed * Time.deltaTime;
    }

    private void Shoot()
    {
        if (_shootTime > 0)
        {
            _shootTime-= Time.deltaTime;
            return;
        }
        if (Input.GetAxis("Shoot") == 1)
        {
            Vector3 bulletSpawn = transform.position + new Vector3(0, 0, 1);
            Instantiate(_bullet, bulletSpawn, transform.localRotation);
            _shootTime = 0.5f;
        }
    }

    private void EventCheck()
    {
        switch (Input.GetAxis("CTRlAndF"))
        {
            case -1:
                Debug.Log("F pressed");
                break;
            case 1:
                Debug.Log("Left CTRL pressed");
                break;
        }
    }

    private void Rotation()
    {
        float degree = Input.GetAxis("Rotation");

        transform.eulerAngles += new Vector3(0, degree, 0) * _speed * Time.deltaTime;
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") == 1)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce);
        }
    }

}
