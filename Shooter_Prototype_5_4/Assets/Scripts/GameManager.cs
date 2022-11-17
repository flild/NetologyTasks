using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private GameObject _bullet;
    [SerializeField] private PlayerControl _player; // так делать незя, но мне лень делать заглушку player)



    private void Start()
    {

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
