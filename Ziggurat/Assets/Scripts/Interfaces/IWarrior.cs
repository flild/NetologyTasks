using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{

    public interface IWarrior
    {
        public WarriorColor color { get; set; }
        public float health { get; set; }
        public float speed { get; set; }
        public float slowAttackDamage { get; set; }
        public float fastAttackDamage { get; set; }
        public float missChance
        {
            get { return missChance; }
            set { missChance = Mathf.Clamp(missChance, 0, 100); }
        }
        public float CritChance
        {
            get { return CritChance; }
            set { CritChance = Mathf.Clamp(CritChance, 0, 100); }
        }
        public float slowAttackChance
        {
            get { return slowAttackChance; }
            set
            {
                slowAttackChance = Mathf.Clamp(slowAttackChance, 0, 100);
                fastAttackChance = 100 - slowAttackChance;
            }
        }
        public float fastAttackChance
        {
            get { return fastAttackChance; }
            set
            {
                fastAttackChance = Mathf.Clamp(fastAttackChance, 0, 100);
                slowAttackChance = 100 - fastAttackChance;
            }
        }

    }
}
