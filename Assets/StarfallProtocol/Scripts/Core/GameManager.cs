using UnityEngine;

namespace StarfallProtocol.Core
{
    public enum GameState
    {
        Playing,
        Paused,
        GameOver
    }

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public GameState CurrentState { get; private set; }
        public float RunTime { get; private set; }

        [SerializeField] private GameObject _pauseMenuUI;
        [SerializeField] private GameObject _gameOverUI;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            CurrentState = GameState.Playing;
            RunTime = 0f;
            Time.timeScale = 1f;
        }

        private void Update()
        {
            if (CurrentState == GameState.Playing)
            {
                RunTime += Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        public void TogglePause()
        {
            if (CurrentState == GameState.GameOver) return;

            if (CurrentState == GameState.Playing)
            {
                CurrentState = GameState.Paused;
                Time.timeScale = 0f;
                _pauseMenuUI?.SetActive(true);
            }
            else if (CurrentState == GameState.Paused)
            {
                CurrentState = GameState.Playing;
                Time.timeScale = 1f;
                _pauseMenuUI?.SetActive(false);
            }
        }

        public void TriggerGameOver()
        {
            if (CurrentState == GameState.GameOver) return;

            CurrentState = GameState.GameOver;
            Time.timeScale = 0f;

            ScoreManager.Instance?.SaveHighscore();
            _gameOverUI?.SetActive(true);
        }

        public void RestartRun()
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        public void ReturnToMainMenu()
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}