using UnityEngine;
using TMPro;
using StarfallProtocol.Core;

namespace StarfallProtocol.UI
{
    public class ScoreDisplayUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        private void Update()
        {
            if (ScoreManager.Instance != null)
            {
                _scoreText.text = $"Score: {ScoreManager.Instance.CurrentScore}";
            }
        }
    }
}