using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Zenject;

namespace Ziggurat
{
    public class UIManager : MonoBehaviour
    {
        //events
        public delegate void HealthContainer(bool showHealth);
        public event HealthContainer ShowHealthButtonPressed;
        public delegate void KillContainer();
        public event KillContainer KillAll;


        private bool isHealthShowed = true;
        private WarriorManager _warriorManager;
        [SerializeField] private ZigguratCard[] _zigguratCardsMas;



        public Dictionary<WarriorColor, InfoZiggurat> zigguratSettings { get; private set; }
        public Dictionary<WarriorColor, ZigguratCard> zigguratCards { get; private set; }


        private void Awake()
        {
            zigguratSettings = new();

            zigguratCards = new();
            
            foreach (var setting in _zigguratCardsMas)
            {
                zigguratCards[setting.GetColor()] = setting;
            }

        }
        private void Start()
        {
            _warriorManager = GetComponent<WarriorManager>();
            foreach (var ziggurat in _warriorManager.GetZiggurats())
            {
                InfoZiggurat setting = ziggurat.GetComponentInChildren<InfoZiggurat>();
                zigguratSettings[ziggurat.color] = setting;
                setting.gameObject.SetActive(false);
            }
        }
        public void OnShowHelthPressed_UnityEditor()
        {
            isHealthShowed = !isHealthShowed;
            Debug.Log("Show health: " + isHealthShowed);
            ShowHealthButtonPressed(isHealthShowed);
        }
        public void OnAllKillPressed_UnityEditor()
        {
            Debug.Log("All Killed");
            KillAll();
        }

        public void ChangeUnitCount(Canvas card, int value)
        {
            var texts = card.GetComponentsInChildren<TMP_Text>();
            foreach (var text in texts)
            {
                if (text.CompareTag("Unit_Count"))
                {

                    text.text = "Unit's life count: " + value;
                }
            }
        }
        public void CountdownChange(float value)
        {
            foreach (var card in zigguratCards)
            {
                var texts = card.Value.GetComponentsInChildren<TMP_Text>();
                foreach (var text in texts)
                {
                    if (text.CompareTag("countdown"))
                    {

                        text.text = "countdown: " + value;
                    }
                }
            }
        }

        public void CleanButtonPressed_UnityEditor(Ziggurat ziggurat)
        {
            ChangeUnitCount(zigguratCards[ziggurat.color].GetComponent<Canvas>(), 0);
            ziggurat.AllUnitDie();
        }
    }
}

