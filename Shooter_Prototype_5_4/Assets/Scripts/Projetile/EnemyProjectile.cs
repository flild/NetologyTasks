using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour, IProjectileData
{
    public ProjecttileType type { get; } = ProjecttileType.FromEnemy;

    public float damage { get; } = 15;
    public float speed { get; } = 15;
    public float lifeTime { get; } = 3;
}
