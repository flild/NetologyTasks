using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, EnemyData
{
    public delegate void MethodContainer(GameObject fromEnemy);
    public event MethodContainer onEnemyDeath;
    public EnemyType type { get; set; } = EnemyType.baseEnemy;
    public float health { get; set; } = 75;
    public ProjecttileType projectileType { get; set; } = ProjecttileType.FromEnemy;
    public float attackSpeed { get; set; } = 3;
    public float attackRadius { get; set; } = 4;
    public float speed { get; set; } = 0;
    private EnemyData currentEnemy;
    private void Start()
    {
        currentEnemy = gameObject.GetComponent<EnemyData>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.TryGetComponent<PlayerProjectile>(out PlayerProjectile playerBullet))
        {
            health -= playerBullet.damage;
            if (health <= 0) onEnemyDeath(gameObject);
            Debug.Log(health <= 0);
        }
    }
}
