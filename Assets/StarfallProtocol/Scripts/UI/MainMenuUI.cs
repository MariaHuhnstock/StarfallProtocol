using UnityEngine;
using UnityEngine.SceneManagement;

namespace StarfallProtocol.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private string _gameSceneName = "Game";

        public void OnPlayButtonPressed()
        {
            SceneManager.LoadScene(_gameSceneName);
        }

        public void OnQuitButtonPressed()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}