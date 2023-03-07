using RotaryHeart.Lib.SerializableDictionary;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
	public enum AnimationType : byte
	{
		Move = 0,
		FastAttack = 1,
		StrongAttack = 2,
		Die = 3
	}

	[System.Flags]
	public enum IgnoreAxisType : byte
	{
		None = 0,
		X = 1,
		Y = 2,
		Z = 4
	}

	[System.Serializable]
	public class AnimationKeyDictionary : SerializableDictionaryBase<AnimationType, string> { }

	public enum WarriorColor
	{
		None = 0,
		Blue = 1,
		Red = 2,
		Green = 3
    }
    public enum AttackType
    {
		SlowAttack = 0,
		FastAttack = 1,
	}

	public enum UnitInfoType
	{
		health = 0,
		speed = 1,
		fastAttackDamage = 2,
		slowAttackDamage = 3,
		missChance = 4,
		critChance = 5,
		slowAttackChance = 6,
		fastAttackChance = 7
	}

	public enum ActionType
	{
		Wandering = 0,
		Attack = 1,
		MoveTo = 2,
		Fear = 3
	}

}
