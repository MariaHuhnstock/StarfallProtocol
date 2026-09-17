using UnityEngine;
using StarfallProtocol.Core;

namespace StarfallProtocol.UI
{
    public class PauseUI : MonoBehaviour
    {
        public void OnResumeButtonPressed()
        {
            GameManager.Instance?.TogglePause();
        }

        public void OnMainMenuButtonPressed()
        {
            GameManager.Instance?.ReturnToMainMenu();
        }
    }
}