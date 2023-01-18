using UnityEngine;
using UnityEngine.UI;



namespace Arcanoid.UI
{
    public class SettingManager : MonoBehaviour
    {
        private TextFileManager _textFileManager;
        [SerializeField, Tooltip("Нужно для переходов")] private GameObject _pausePanel;
        [SerializeField,Tooltip("Чек бокс включенного звука")] private Toggle _soundOnBox;
        [SerializeField,Tooltip("слайдер")] private Slider _soundValueSlider;
        [SerializeField, Tooltip("Чек боксы уровня сложности")] private Toggle _easyToggle;
        [SerializeField, Tooltip("Чек боксы уровня сложности")] private Toggle _normalToggle;
        [SerializeField, Tooltip("Чек боксы уровня сложности")] private Toggle _hardToggle;

        private void Start()
        {
            _textFileManager = GetComponent<TextFileManager>();
            _textFileManager.GetSettings(out bool _soundOn, out float _soundValue, out Difficult _difficult);

            _soundOnBox.SetIsOnWithoutNotify(_soundOn);
            _soundValueSlider.SetValueWithoutNotify(_soundValue);
            switch(_difficult)
            {
                case Difficult.easy:
                    _easyToggle.SetIsOnWithoutNotify(true);
                    break;
                case Difficult.normal:
                    _normalToggle.SetIsOnWithoutNotify(true);
                    break;
                case Difficult.hard:
                    _hardToggle.SetIsOnWithoutNotify(true);
                    break;
            }

        }
        public void OnSoundCheckChange_UnityEditor(bool value)
        {
            _textFileManager.RecordSettings(RecordSettingType.sound, value.ToString());
        }

        public void OnSoundSliderChange_UnityEditor(float value)
        {
            _textFileManager.RecordSettings(RecordSettingType.soundValue, value.ToString());
        }

        public void OnEasyToggle_UnityEditor(bool value)
        {
            _normalToggle.SetIsOnWithoutNotify(false);
            _hardToggle.SetIsOnWithoutNotify(false);
            _textFileManager.RecordSettings(RecordSettingType.difficutly, Difficult.easy.ToString());
        }
        public void OnNormalToggle_UnityEditor(bool value)
        {
            _easyToggle.SetIsOnWithoutNotify(false);
            _hardToggle.SetIsOnWithoutNotify(false);
            _textFileManager.RecordSettings(RecordSettingType.difficutly, Difficult.normal.ToString());
        }
        public void OnHardToggle_UnityEditor(bool value)
        {
            _normalToggle.SetIsOnWithoutNotify(false);
            _easyToggle.SetIsOnWithoutNotify(false);
            _textFileManager.RecordSettings(RecordSettingType.difficutly, Difficult.hard.ToString());
        }
        public void OnBackToMenu_UnityEditor()
        {
            gameObject.SetActive(false);
            _pausePanel.SetActive(true);
        }


    }
}
