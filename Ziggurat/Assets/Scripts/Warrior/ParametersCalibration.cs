using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class ParametersCalibration : MonoBehaviour
    {
        private FieldOfView _FOV;
        private Warrior _warrior;
        private Dictionary<ActionType, float> _actionsWeight;
        private Dictionary<AttackType, float> _attacksWeight;
        private bool _isHaveTarget = false;

        private void Start()
        {
            _FOV = GetComponent<FieldOfView>();
            _warrior = GetComponent<Warrior>();
            //xml 
            _actionsWeight = WeightConfigAssistent.GetActionWeights();
            _attacksWeight = WeightConfigAssistent.GetAttackWeights();
            StartCoroutine(CalibrationLoop());
        }
        private void Calibration()
        {

            float distance = _FOV.GetDistanceToNearstTarget();
            if (distance < 1) distance = 1;
            float ViewRadius = _FOV.GetViewRadius();
            if (distance >= ViewRadius)
            {
                _actionsWeight[ActionType.Wandering] = 20;
                _actionsWeight[ActionType.Fear] = 0;
                _actionsWeight[ActionType.MoveTo] = 0;
                _actionsWeight[ActionType.Attack] = 0;
            }
            if (distance >=1 && distance < ViewRadius)
            {
                _actionsWeight[ActionType.Wandering] = 0;
                _actionsWeight[ActionType.MoveTo] = 2 * distance;
                _actionsWeight[ActionType.Attack] += ViewRadius / distance;
            }
            float health = _warrior.health;
            float maxHealth = _warrior.maxHealth;
            if (health <= 0)
            {
                _warrior.Die();
                return;
            }
            float healthSize = maxHealth / health;
            if (healthSize >3)
            {
                _actionsWeight[ActionType.Fear] += 20;
            }
        }
        private IEnumerator CalibrationLoop()
        {
            while (true)
            {
                Calibration();
                yield return new WaitForSeconds(3);
            }
        }
        public ActionType GetActionType()
        {
            float maxValue = float.MinValue;
            ActionType type = ActionType.Wandering;
            foreach (var action in _actionsWeight)
            {
                if (action.Value > maxValue)
                {
                    maxValue = action.Value;
                    type = action.Key;
                }
            }
            return type;
        }
        public AttackType GetAttackType()
        {
            float maxValue = float.MinValue;
            AttackType type = AttackType.FastAttack;
            foreach (var action in _attacksWeight)
            {
                if (action.Value > maxValue)
                {
                    maxValue = action.Value;
                    type = action.Key;
                }
            }
            return type;
        }


    }
}
