using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public EnemyType type;
    public float health;
    public ProjecttileType projectileType;

    public float attackSpeed;
    public float attackRadius;

    public float speed;

    
    /// <summary>
    /// Структура для всех врагов в игре
    /// </summary>
    /// <param name="type">Тип врага из enum EnemyType</param>
    /// <param name="health">Здоровье врага</param>
    /// <param name="projectileType">Тип снарядов, какими стреляет враг</param>
    /// <param name="attackSpeed">Скорость стрельбы вычисляется, как (maxAttackSpeed - значение)/100 = количество секунд.
    /// всё что больше maxAttackSpeed, будет приравнено к maxAttackSpeed. При такой скорости враг атакует без перезарядки</param>
    /// <param name="attackRadius">Радиус в котором враг автоматически атакует игрока</param>
    /// <param name="speed">Скорость перемещения врага(В данном задание они стоят на месте)</param>
    public EnemyData(EnemyType type,
                     float health,
                     ProjecttileType projectileType,
                     float attackSpeed,
                     float attackRadius,
                     float speed)   
    {
        float maxAttackSpeed = 1000;
        float minAttackSpeed = 0;

        this.type = type;
        this.health = health;
        this.projectileType = projectileType;

        if (attackSpeed > maxAttackSpeed) this.attackSpeed = maxAttackSpeed;
        if (attackSpeed<minAttackSpeed) this.attackSpeed = minAttackSpeed;
        this.attackSpeed = (maxAttackSpeed - attackSpeed) / 100;

        this.attackRadius = attackRadius;
        this.speed = speed;
    }
}
