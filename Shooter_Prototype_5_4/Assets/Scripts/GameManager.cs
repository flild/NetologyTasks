using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private List<GameObject> _enemies = new();
    private Dictionary<GameObject,Enemy> _enemiesScript = new();
    public List <GameObject> _projectiles = new();
    private Vector3 _bulletSpawn;
    private PlayerControl _playerControl;


    [SerializeField] private int _enemyCount;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _bulletPlayer;
    [SerializeField] private GameObject _bulletEnemy;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _bulletSpeed;



    private void Start()
    {
        _playerControl = _player.GetComponent<PlayerControl>();
        for (int i = 0; i < _enemyCount; i++)
        {
            Vector3 randomSpawn = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform.position;
            GameObject current_enemy = Instantiate(_enemyPrefab, randomSpawn, Quaternion.Euler(0, Random.Range(0, 360), 0));
            _enemies.Add(current_enemy);
        }
        foreach(GameObject enemy in _enemies )
        {
            AttackRadius CollisionWithPlayer = enemy.GetComponentInChildren<AttackRadius>();
            CollisionWithPlayer.onPlayerCollision += AttackOnPlayer;
            Enemy currentEnemy = enemy.GetComponentInChildren<Enemy>();
            currentEnemy.onEnemyDeath += EnemyDeath;
            _enemiesScript.Add(enemy,enemy.GetComponent<Enemy>());
        }
        _playerControl.onShootEvent += OnPlayerShoot;
    }
    private void Update()
    {
        EnemyCheck();
        
    }
    private void FixedUpdate()
    {
        ProjectileCheck();
    }

    private void EnemyCheck()
    {
        foreach(var enemy in _enemies)
        {
            //if (enemy.health <= 0) EnemyDeath(enemy.Key);
         
            
        }
    }
    private void ProjectileCheck()
    {
        foreach(var projectile in _projectiles)
        {
            projectile.transform.position += projectile.transform.forward* _bulletSpeed* Time.fixedDeltaTime;
        }
    }


    private void EnemyDeath(GameObject enemy)
    {
        enemy.SetActive(false);
        enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform.position;
        enemy.SetActive(true);
        _enemiesScript[enemy].health = 75;
    }

    private void AttackOnPlayer(Transform enemyTransform, Enemy fromEnemy)
    {
        enemyTransform.LookAt(_player.transform);
        StartCoroutine(ShootToPlayer(enemyTransform.position,enemyTransform.localRotation, fromEnemy));
    }

    private void OnPlayerShoot()
    {
        Shoot(ProjecttileType.FromPlayer, _player.transform, _player.transform.position + Vector3.forward, _bulletPlayer);
    }
    private IEnumerator ShootToPlayer(Vector3 enemyPosition,Quaternion bulletRotation, Enemy fromEnemy)
    {
        
        float distanceToPlayer = Vector3.Distance(_player.transform.position, enemyPosition);
        Debug.Log(distanceToPlayer >= fromEnemy.attackRadius);
        while (distanceToPlayer >= fromEnemy.attackRadius)
        {
            fromEnemy.transform.LookAt(_player.transform.position);
            distanceToPlayer = Vector3.Distance(_player.transform.position, enemyPosition);
            Shoot(ProjecttileType.FromEnemy, fromEnemy.transform,_player.transform.position, _bulletEnemy);
            yield return new WaitForSeconds(fromEnemy.attackSpeed);
        }

    }
    public void Shoot(ProjecttileType BulletType, Transform source, Vector3 target, GameObject ProjectilePrefab)
    {
        Vector3 _projectileSpawn = source.localPosition;
        GameObject current_bullet = Instantiate(ProjectilePrefab, _projectileSpawn+source.up + source.forward, source.rotation);
        _projectiles.Add(current_bullet);
    }


    private void OnDisable()
    {
        
    }

}
