using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private BallSpawnPoint _freezePoint;
    private Platform _currentPlatform;
    private bool isFreezeToShoot = true;
    private PlayersConrol _input;
    private Rigidbody _rb;
    private float _ballSpeed = 200f;
   // private Vector3 

    private Vector3 _normal;
    private Vector3 _reflection;


    private void Awake()
    {
        _input = new PlayersConrol();
    }
    private void OnEnable()
    {
        _input.Enable();
        _input.Players.Shoot.performed += OnShootBall;
    }
    private void OnDisable()
    {
        _input.Disable();
    }
    private void Start()
    {
        var startPlatform = FindObjectOfType<FirstPlayerControl>();
        
        _currentPlatform = startPlatform.GetComponent<Platform>();
        _freezePoint = startPlatform.GetComponentInChildren<BallSpawnPoint>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(isFreezeToShoot)
        {
            transform.position = _freezePoint.transform.position;
        }
    }

    private void OnShootBall(CallbackContext context)
    {
        _rb.AddForce(_currentPlatform.transform.forward * _ballSpeed, ForceMode.Force);
        //_rb.velocity = _currentPlatform.transform.forward * _ballSpeed;
        isFreezeToShoot = false;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_normal, _reflection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        _normal = collision.contacts[0].normal;
        _reflection = Vector3.Reflect(_rb.velocity,_normal);

        _rb.velocity = _reflection;

    }

}
