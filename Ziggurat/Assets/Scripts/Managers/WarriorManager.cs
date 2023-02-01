using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class WarriorManager : MonoBehaviour
    {
        [SerializeField] Ziggurat _blueZiggurat;
        [SerializeField] Ziggurat _greenZiggurat;
        [SerializeField] Ziggurat _redZiggurat;
        private List<GameObject> _blueWarriors;
        private List<GameObject> _greenWarriors;
        private List<GameObject> _redWarriors;
        [SerializeField] private float _spawnDelay;

        private void Start()
        {
            StartCoroutine(SpawnUnits());
        }
        public GameObject spawnWarrior(WarriorColor color)
        {
            Debug.Log(color);
            switch (color)
            {
                case WarriorColor.Blue:
                    return Instantiate(_blueZiggurat.GetWarriorPrefab(),
                                _blueZiggurat.GetUnitSpawnPosition(),
                                _blueZiggurat.GetUnitQuaternion(),
                                transform);
                case WarriorColor.Red:
                    return Instantiate(_redZiggurat.GetWarriorPrefab(),
                                _redZiggurat.GetUnitSpawnPosition(),
                                _redZiggurat.GetUnitQuaternion(),
                                transform);
                case WarriorColor.Green:
                    return Instantiate(_greenZiggurat.GetWarriorPrefab(),
                                _greenZiggurat.GetUnitSpawnPosition(),
                                _greenZiggurat.GetUnitQuaternion(),
                                transform);
                default:
                    Debug.Log("null exeption in spawn");
                    return null;
            }
            
        }

        IEnumerator SpawnUnits()
        {
            bool flag = true;
            while (flag)
            {
                _blueWarriors.Add(spawnWarrior(WarriorColor.Blue));
                _redWarriors.Add(spawnWarrior(WarriorColor.Red));
                _greenWarriors.Add(spawnWarrior(WarriorColor.Green));
                yield return new WaitForSeconds(_spawnDelay);
                flag = false;
            }
            
        }





    }
}