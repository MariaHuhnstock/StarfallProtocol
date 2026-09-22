using StarfallProtocol.Core;
using UnityEngine;
using UnityEngine.UI;

public class EarthHealthBarUI : MonoBehaviour
{
    [SerializeField] private EarthHealth earthHealth;
    [SerializeField] private Image fillImage;

    private void OnEnable()
    {
        earthHealth.OnHealthChanged += UpdateBar;
        earthHealth.OnEarthDestroyed += HandleGameOver;
    }

    private void OnDisable()
    {
        earthHealth.OnHealthChanged -= UpdateBar;
        earthHealth.OnEarthDestroyed -= HandleGameOver;
    }

    private void UpdateBar(float normalizedHealth)
    {
        fillImage.fillAmount = normalizedHealth;
    }

    private void HandleGameOver()
    {
        // an euren GameManager weiterreichen, z. B.:
        GameManager.Instance.TriggerGameOver();
    }
}