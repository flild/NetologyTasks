using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForwardMove : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _normal;
    [SerializeField] private float _playerSpeed;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(MoveForward());
    }
    private IEnumerator MoveForward()
    {
        while (true)
        {
            Vector3 normal_vector = Vector3.forward - Vector3.Dot(Vector3.forward, _normal) * _normal;
            _rb.velocity += normal_vector * _playerSpeed*Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _normal = collision.contacts[0].normal;
    }

    private void OnCollisionExit(Collision collision)
    {
        _normal = Vector3.zero;
    }

}
