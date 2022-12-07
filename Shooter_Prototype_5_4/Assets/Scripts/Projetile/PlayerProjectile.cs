using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour, IProjectileData
{
    private GameManager _gameManager;
    public ProjecttileType type { get; } = ProjecttileType.FromPlayer;

    public float damage { get; } = 50;
    public float speed { get; } = 10;
    public float lifeTime { get; } = 4;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Destroy");
        if (!collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            
            _gameManager._projectiles.Remove(gameObject);
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
    }

}
