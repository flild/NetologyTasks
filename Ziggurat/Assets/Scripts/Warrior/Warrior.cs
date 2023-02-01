using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ziggurat
{
    [RequireComponent(typeof(Rigidbody))]
    public class Warrior : MonoBehaviour, IWarrior
    {
        //stats
        public WarriorColor color { get; set; }
        public float health { get; set; }
        public float speed { get; set; }
        public float slowAttackDamage { get; set; }
        public float fastAttackDamage { get; set; }
        public float missChance { get; set; }
        public float slowAttackChance { get; set; }
        public float fastAttackChance { get; set; }

        private Rigidbody _rb;
        private Ziggurat _ziggurat;

        private void Start()
        {
            Debug.Log("Spawn unit");
            Initialisation();
            _rb.velocity = transform.forward * speed;

        }
        private void Initialisation()
        {
            _ziggurat = GetComponentInParent<Ziggurat>();
            color = _ziggurat.color;
            health = _ziggurat.GetUnitInfo(UnitInfoType.health);
            speed = _ziggurat.GetUnitInfo(UnitInfoType.speed);
            slowAttackDamage = _ziggurat.GetUnitInfo(UnitInfoType.slowAttackDamage);
            fastAttackDamage = _ziggurat.GetUnitInfo(UnitInfoType.fastAttackDamage);
            missChance = _ziggurat.GetUnitInfo(UnitInfoType.missChance);
            slowAttackChance = _ziggurat.GetUnitInfo(UnitInfoType.slowAttackChance);
            fastAttackChance = _ziggurat.GetUnitInfo(UnitInfoType.fastAttackChance);

            _rb = GetComponent<Rigidbody>();
        }

    }
}

