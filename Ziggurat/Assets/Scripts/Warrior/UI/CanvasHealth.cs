using UnityEngine;
using UnityEngine.UI;

namespace Ziggurat
{
    public class CanvasHealth : MonoBehaviour
    {
        [SerializeField]private Slider _healthValue;
        private UIManager _UIManager;
        private Warrior _warrior;
        private void Start()
        {
            GetComponent<Canvas>().worldCamera = Camera.main;
            _warrior = GetComponentInParent<Warrior>();
            _UIManager = FindObjectOfType<UIManager>();

            _UIManager.ShowHealthButtonPressed += OnPressedShowHealth;

            _healthValue.maxValue = _warrior.maxHealth;
            _healthValue.value = _warrior.maxHealth;

        }
        public void TakeDamage(float damageValue)
        {
            _healthValue.value -= damageValue;
        }
        public void TakeHeal(float healValue)
        {
            _healthValue.value += healValue;
        }

        private void OnPressedShowHealth(bool isShow)
        {
                gameObject.SetActive(isShow);
        }
        private void OnDestroy()
        {
            _UIManager.ShowHealthButtonPressed -= OnPressedShowHealth;
        }
    }
}

