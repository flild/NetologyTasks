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
    /// ��������� ��� ���� �������� � ����
    /// </summary>
    /// <param name="Type">��� ������� �� ���, ��� �������� � enum ProjecttileType</param>
    /// <param name="damage">���� ������� ��� ���������</param>
    /// <param name="speed">�������� ������ �������</param>
    /// <param name="lifeTime">����� ����� ������� � ��������</param>
    public ProjectileData(ProjecttileType Type, float damage, float speed, float lifeTime)
    {
        this.type = Type;
        this.damage = damage;   
        this.speed = speed; 
        this.lifeTime = lifeTime;
    }
}
