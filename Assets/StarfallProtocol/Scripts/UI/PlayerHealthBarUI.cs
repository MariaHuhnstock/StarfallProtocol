using StarfallProtocol.Player;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image fillImage;

    private void OnEnable()
    {
        playerHealth.OnHealthChanged += UpdateBar;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= UpdateBar;
    }

    private void UpdateBar(float normalizedHealth)
    {
        fillImage.fillAmount = normalizedHealth;
    }
}