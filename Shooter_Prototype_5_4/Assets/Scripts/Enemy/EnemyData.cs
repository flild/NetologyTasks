using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyData
{

    public EnemyType type { get; }
    public float health { get; }
    public ProjecttileType projectileType { get; }

    public float attackSpeed { get; }
    public float attackRadius { get; }

    public float speed { get; }
}
