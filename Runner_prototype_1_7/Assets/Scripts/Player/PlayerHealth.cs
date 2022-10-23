using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))] 
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _healthCount;

    private GameObject _gameManager;
    private PlayerHeathUI _healthText;
    private Rigidbody _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();    
        _gameManager = transform.parent.gameObject;
        _healthText = _gameManager.GetComponentInChildren<PlayerHeathUI>();
    }

    private void Update()
    {
        if (transform.transform.position.y <= 0 ) Kill();
    }
    public void Hit(float damage)
    {
        _healthCount -= damage;
        _healthText.ShowHeath(_healthCount);
        _rb.velocity -= new Vector3(0, 0, 1);
        if (_healthCount <= 0)
            EditorApplication.isPaused = true;
    }

    public void Kill()
    {
        Hit(_healthCount);
    }
}
