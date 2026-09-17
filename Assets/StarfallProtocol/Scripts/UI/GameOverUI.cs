using UnityEngine;
using TMPro;
using StarfallProtocol.Core;

namespace StarfallProtocol.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _finalScoreText;
        [SerializeField] private TMP_Text _highscoreText;

        private void OnEnable()
        {
            if (ScoreManager.Instance == null) return;

            _finalScoreText.text = $"Score: {ScoreManager.Instance.CurrentScore}";
            _highscoreText.text = $"Highscore: {ScoreManager.Instance.Highscore}";
        }

        public void OnRestartButtonPressed()
        {
            GameManager.Instance?.RestartRun();
        }

        public void OnMainMenuButtonPressed()
        {
            GameManager.Instance?.ReturnToMainMenu();
        }
    }
}