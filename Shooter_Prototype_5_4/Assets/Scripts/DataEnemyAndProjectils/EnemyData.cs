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
    /// ��������� ��� ���� ������ � ����
    /// </summary>
    /// <param name="type">��� ����� �� enum EnemyType</param>
    /// <param name="health">�������� �����</param>
    /// <param name="projectileType">��� ��������, ������ �������� ����</param>
    /// <param name="attackSpeed">�������� �������� �����������, ��� (maxAttackSpeed - ��������)/100 = ���������� ������.
    /// �� ��� ������ maxAttackSpeed, ����� ���������� � maxAttackSpeed. ��� ����� �������� ���� ������� ��� �����������</param>
    /// <param name="attackRadius">������ � ������� ���� ������������� ������� ������</param>
    /// <param name="speed">�������� ����������� �����(� ������ ������� ��� ����� �� �����)</param>
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
