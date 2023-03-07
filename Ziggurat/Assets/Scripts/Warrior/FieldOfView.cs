using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;
using System;

namespace Ziggurat
{
    internal class FieldOfView : MonoBehaviour, IFOV
    {
        [Header("Field of View Parameters")]
        [SerializeField] private float _viewRadius = 20f;
        [SerializeField] private float _refreshDelay;

        [Header("Layer Mask")]
        [SerializeField] private LayerMask _targetMask; //подумать надо

        // Targets Data
        private bool _hasTargets = false;
        private Transform _currentTarget = null;
        private float _minDistance;
        private List<Transform> _targetsList = new List<Transform>();
        private Warrior _warrior;
        private WarriorColor _selfColor;

        // Public Fields
        public float Radius => _viewRadius;
        public Transform CurrentTargetTransform => _currentTarget;

        private void OnDrawGizmos()
        {
            UnityEditor.Handles.DrawWireDisc(transform.position, transform.up, _viewRadius);
        }
        private void Start()
        {
            _minDistance = _viewRadius + 1;
            _warrior = GetComponent<Warrior>();
            _selfColor = _warrior.color;
            StartCoroutine(StartRefresh());
        }

        private IEnumerator StartRefresh()
        {
            while(true)
            {
                RefreshTargetList();
                yield return new WaitForSeconds(_refreshDelay);
            }
        }
        private void RefreshTargetList()
        {
            _targetsList = new List<Transform>();
            Collider[] collidersInRadius = Physics.OverlapSphere(transform.position, _viewRadius, _targetMask);
            if (collidersInRadius.Length == 0) return;
            foreach(var target in collidersInRadius)
            {
                if (target.TryGetComponent<Warrior>(out Warrior targetWarrior))
                {
                    if (targetWarrior.color == _selfColor)
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
                _targetsList.Add(target.transform);
                _hasTargets = true;
            }

        }


        public List<Transform> GetAllTargets()
        {
            return _targetsList;
        }

        public Transform GetNearestTarget()
        {
            _minDistance = _viewRadius + 1;
            if (_targetsList.Count < 1) return null;
            Transform nearestTarget = null;
            foreach (var target in _targetsList)
            {
                Vector3 offset = transform.position - target.transform.position;
                float distanceToTarget = offset.sqrMagnitude;
                if (distanceToTarget < _minDistance)
                {
                    nearestTarget = target.transform;
                    _minDistance = distanceToTarget;
                }
            }

            return nearestTarget;
        }
        public float GetDistanceToNearstTarget()
        {
            GetNearestTarget();
            return _minDistance;
        }

        public bool HasTargets()
        {
            return _hasTargets;
        }

        public void ForceRecalculate()
        {
            RefreshTargetList();
        }
        public float GetViewRadius()
        {
            return _viewRadius;
        }
    }
}

