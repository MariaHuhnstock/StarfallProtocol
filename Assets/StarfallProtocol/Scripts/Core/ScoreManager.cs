using UnityEngine;

namespace StarfallProtocol.Core
{
    /// <summary>
    /// Einfacher Singleton, der den Score während eines Runs zählt
    /// und den Highscore über PlayerPrefs speichert.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        private const string HighscoreKey = "Starfall_Highscore";

        public int CurrentScore { get; private set; }
        public int Highscore { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            Highscore = PlayerPrefs.GetInt(HighscoreKey, 0);
        }

        public void AddScore(int amount)
        {
            CurrentScore += amount;

            if (CurrentScore > Highscore)
            {
                Highscore = CurrentScore;
            }
        }

        public void ResetScore()
        {
            CurrentScore = 0;
        }

        /// <summary>
        /// Aufrufen bei Game Over, damit der Highscore dauerhaft gespeichert wird.
        /// </summary>
        public void SaveHighscore()
        {
            PlayerPrefs.SetInt(HighscoreKey, Highscore);
            PlayerPrefs.Save();
        }
    }
}