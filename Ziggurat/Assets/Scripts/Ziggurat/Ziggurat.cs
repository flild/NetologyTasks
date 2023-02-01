using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class Ziggurat : MonoBehaviour, IZiggurat
    {
        [SerializeField] private GameObject _warriorPrefab;
        [SerializeField] private Transform _unitSpawn;
        [SerializeField] private InfoZiggurat _unitStat;
        public WarriorColor color;

        public GameObject GetWarriorPrefab()
        {
            return _warriorPrefab;
        }
        public Vector3 GetUnitSpawnPosition()
        {
            return _unitSpawn.position;
        }
        public Quaternion GetUnitQuaternion()
        {
            return _unitSpawn.localRotation;
        }

        public float GetUnitInfo(UnitInfoType type)
        {
            return _unitStat.GetUnitInfo(type);
        }
            
    }
}

