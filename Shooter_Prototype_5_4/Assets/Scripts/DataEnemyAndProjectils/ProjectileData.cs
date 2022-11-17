using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ProjectileData
{
    public ProjecttileType type;

    public float damage;
    public float speed;
    public float lifeTime;
    /// <summary>
    /// Структура для всех снарядов в игре
    /// </summary>
    /// <param name="Type">тип Снаряда из тех, что записаны в enum ProjecttileType</param>
    /// <param name="damage">Урон снаряда при попадании</param>
    /// <param name="speed">Скорость полета снаряда</param>
    /// <param name="lifeTime">Время жизни снаряда в секундах</param>
    public ProjectileData(ProjecttileType Type, float damage, float speed, float lifeTime)
    {
        this.type = Type;
        this.damage = damage;   
        this.speed = speed; 
        this.lifeTime = lifeTime;
    }
}
