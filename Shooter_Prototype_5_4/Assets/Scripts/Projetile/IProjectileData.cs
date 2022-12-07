using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileData
{
    public ProjecttileType type { get; }

    public float damage { get; }
    public float speed { get; }
    public float lifeTime { get; }
}
