using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadius : MonoBehaviour
{
    private Player _player;
    private Enemy _currentEnemy;
    public delegate void MethodContainer(Transform enemy, Enemy fromEnemy);
    public event MethodContainer onPlayerCollision;

    private void Start()
    {
        _player = GetComponent<Player>();
        _currentEnemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            onPlayerCollision(_currentEnemy.transform, _currentEnemy);
        }
    }
}
