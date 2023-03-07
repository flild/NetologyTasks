using UnityEngine;
using Zenject;


namespace Ziggurat
{
    [RequireComponent(typeof(WarriorManager))]
    public class GameManager : MonoInstaller
    {
        private WarriorManager _warriorManager;
        private Transform _centerMap;
        private UIManager _UIManager;


        private void OnValidate()
        {
           
        }
        private void Awake()
        {  
        }
        public override void InstallBindings()
        {
            _centerMap = transform;
            _warriorManager = GetComponent<WarriorManager>();
            _UIManager = GetComponent<UIManager>();
            Container.BindInstance(_warriorManager).AsSingle();
            Container.BindInstance(_UIManager).AsSingle();
            Container.BindInstance(_centerMap);
        }



    }
}
