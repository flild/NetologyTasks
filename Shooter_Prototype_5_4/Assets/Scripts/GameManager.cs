using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private Dictionary<GameObject,EnemyData> _enemies = new Dictionary<GameObject, EnemyData>();
    private Dictionary<GameObject, ProjectileData> _projectiles = new Dictionary<GameObject, ProjectileData>();
    private Vector3 _bulletSpawn;
    // По хорошему тут нужно сделать файл со всеми типа оружия и снарядов и уже оттуда подтягивать данные,
    // но у меня другая задача, поэтому хардкодим
    private Dictionary<ProjecttileType, ProjectileData> ProjectailesSetting = new Dictionary<ProjecttileType, ProjectileData>()
    {
        {ProjecttileType.FromPlayer, new ProjectileData(ProjecttileType.FromPlayer, 50, 100, 4)},
        {ProjecttileType.FromEnemy, new ProjectileData(ProjecttileType.FromEnemy,15, 60, 2) },
        {ProjecttileType.FromBoss, new ProjectileData(ProjecttileType.FromBoss, 25, 110, 2) }
    };
    private Dictionary<EnemyType, EnemyData> EnemySetting = new Dictionary<EnemyType, EnemyData>()
    {
        {EnemyType.baseEnemy, new EnemyData(EnemyType.baseEnemy, 75, ProjecttileType.FromEnemy,300, 5,0)},
        {EnemyType.npc, new EnemyData(EnemyType.npc, 50, ProjecttileType.FromEnemy,0, 0,0)},
        {EnemyType.boss, new EnemyData(EnemyType.boss, 50, ProjecttileType.FromBoss,600,7,0)},
    };

    [SerializeField] private int _enemyCount;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private PlayerControl _player; // так делать незя, но мне лень делать заглушку player)
    [SerializeField] private GameObject[] _spawnPoints;



    private void Start()
    {
        for(int i = 0; i < _enemyCount; i++)
        {
            Vector3 randomSpawn = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform.position;
            GameObject current_enemy = Instantiate(_enemyPrefab, randomSpawn, Quaternion.Euler(0, Random.Range(0, 360), 0));
            _enemies.Add(current_enemy, EnemySetting[EnemyType.baseEnemy]);
        }
    }
    private void Update()
    {
        
    }

    private void EnemyCheck()
    {
        foreach(var enemy in _enemies)
        {

        }
    }
    public void Shoot(ProjecttileType BulletType, GameObject source, Vector3 target, GameObject ProjectilePrefab)
    {
        // добавляем в словарь снаряд и его характеристики
        Vector3 _projectileSpawn = source.transform.localPosition;
        GameObject current_bullet = Instantiate(ProjectilePrefab, _projectileSpawn, source.transform.localRotation);
        ProjectileData projectileSetting = ProjectailesSetting[BulletType];
        _projectiles.Add(current_bullet, projectileSetting);
    }


}
