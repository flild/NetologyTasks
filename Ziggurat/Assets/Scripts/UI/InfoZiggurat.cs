using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ziggurat
{
    public class InfoZiggurat : MonoBehaviour
    {
		[SerializeField] private Slider _health;
		[SerializeField] private Slider _speed;
		[SerializeField] private Slider _fastAttackDamage;
		[SerializeField] private Slider _slowAttackDamage;
		[SerializeField] private Slider _missChance;
		[SerializeField] private Slider _critChance;
		[SerializeField] private Slider _AttackChance;

		public float GetUnitInfo(UnitInfoType type)
        {
            switch (type)
            {
                case UnitInfoType.health:
                    return _health.value;
                case UnitInfoType.speed:
                    return _speed.value;
                case UnitInfoType.fastAttackDamage:
                    return _fastAttackDamage.value;
                case UnitInfoType.slowAttackDamage:
                    return _slowAttackDamage.value;
                case UnitInfoType.missChance:
                    return _missChance.value;
                case UnitInfoType.critChance:
                    return _critChance.value;
                case UnitInfoType.slowAttackChance:
                    return _AttackChance.value;
                case UnitInfoType.fastAttackChance:
                    return 100 - _AttackChance.value;
                default:
                    return 0;
            }
        }

    }
}

