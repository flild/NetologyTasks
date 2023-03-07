using UnityEngine;
using System.Collections.Generic;
using Zenject;

namespace Ziggurat
{
    public class Ziggurat : MonoBehaviour, IZiggurat
    {
        [SerializeField] private GameObject _warriorPrefab;
        [SerializeField] private Transform _unitSpawn;
        [SerializeField] private InfoZiggurat _unitStat;
        [SerializeField] private Canvas _info;

        private int _unitCount = 0;
        public WarriorColor color;

        [Inject]
        private Transform _centerMap;
        [Inject]
        private UIManager _UIManager;


        private void Start()
        {
            _UIManager.KillAll += AllUnitDie;
        }

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
        public Vector3 GetCenterPosition()
        {
            return _centerMap.position;
        }

        public void SpawnUnit()
        {
            Instantiate(_warriorPrefab, GetUnitSpawnPosition(), GetUnitQuaternion(), transform);
            _unitCount++;
            _UIManager.ChangeUnitCount(_info, _unitCount);
        }
        public void UnitDie()
        {
            if (_unitCount > 0)
            {
                _unitCount--;
            }

            _UIManager.ChangeUnitCount(_info, _unitCount);
        }
        public void AllUnitDie()
        {
            _unitCount = 0;
            _UIManager.ChangeUnitCount(_info, _unitCount);
        }
        private void OnDisable()
        {
            _UIManager.KillAll -= AllUnitDie;
        }

    }
}

