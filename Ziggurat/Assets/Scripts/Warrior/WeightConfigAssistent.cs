using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Ziggurat
{
    public class WeightConfigAssistent : MonoBehaviour
    {
        private static string configPath = "Assets/Resources/config_weight.xml";

        static private Dictionary<ActionType, float> _actionsWeight;
        static private Dictionary<AttackType, float> _attacksWeight;


        static public Dictionary<AttackType, float> GetAttackWeights()
        {
            _attacksWeight = new Dictionary<AttackType, float>();
            var root = XDocument.Load(configPath);
            
            foreach (var element in root.Element("Config").Element("Attacks").Elements("Attack"))
            {
                float attackWeight = float.Parse(element.Attribute("Value").Value);
                AttackType attack = (AttackType)Enum.Parse(typeof(AttackType), element.Attribute("Name").Value);
                _attacksWeight.Add(attack, attackWeight);
            }
            return _attacksWeight;
            


        }
        static public Dictionary<ActionType, float> GetActionWeights()
        {
            var root = XDocument.Load(configPath);
            _actionsWeight = new Dictionary<ActionType, float>();
            foreach (var element in root.Element("Config").Element("Moves").Elements("Move"))
            {
                float actionWeight = float.Parse(element.Attribute("Value").Value);
                ActionType attack = (ActionType)Enum.Parse(typeof(ActionType), element.Attribute("Name").Value);
                _actionsWeight.Add(attack, actionWeight);
            }
            return _actionsWeight;
        }


    }
}

