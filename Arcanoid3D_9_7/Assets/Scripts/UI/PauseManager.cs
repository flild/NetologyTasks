using UnityEngine;
using UnityEngine.SceneManagement;
namespace Arcanoid.UI
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _settingPanel;
        [SerializeField] private LevelSpawn _levelManager;
        public void OnPauseActive_UnityEditor()
        {
            Debug.Log("Open pause menu");
            _pausePanel.SetActive(true);
        }

        public void OnStartGame_UnityEditor()
        {
            SceneManager.LoadScene("MainScene");

        }

        public void OnExitGame_UnityEditor()
        {
            Application.Quit();
        }

        public void OnSettingOpen_UnityEditor()
        {
            _pausePanel.SetActive(false);
            _settingPanel.SetActive(true);
        }

        public void OnResumeGame_UnityEditor()
        {
            Time.timeScale = 1f;
            _pausePanel.SetActive(false);

        }

        public void OnRestartGame_UnityEditor()
        {
            OnResumeGame_UnityEditor();
            _levelManager.ResetGame();
        }
    }
}
