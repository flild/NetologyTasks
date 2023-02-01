using UnityEngine;
using Zenject;
using Unity.Collections;
using System.Collections.Generic;

namespace Ziggurat
{
    [RequireComponent(typeof(WarriorManager))]
    public class GameManager : MonoInstaller
    {
        WarriorManager _warriorManager;


        private void Start()
        {
            _warriorManager = GetComponent<WarriorManager>();
        }
        public override void InstallBindings()
        {
            Container.BindInstance(_warriorManager).AsSingle();
        }



    }
}
