using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
    public class WarriorManager : MonoBehaviour
    {
        [SerializeField] Ziggurat[] _ziggurats;
        [SerializeField] private float _spawnDelay;

        private UIManager _UImanager;

        private void Start()
        {
            _UImanager = GetComponent<UIManager>();
            StartCoroutine(SpawnUnits());
            
        }

        IEnumerator SpawnUnits()
        {
            while (true)
            { 
                foreach( var ziggurat in _ziggurats)
                {
                    ziggurat.SpawnUnit();
                }
                for(float delay = _spawnDelay; delay >0; delay--)
                {
                    _UImanager.CountdownChange(delay);
                    yield return new WaitForSeconds(1);
                }
                
            }
            
        }

        public Ziggurat[] GetZiggurats()
        {
            return _ziggurats;
        }
    }
}