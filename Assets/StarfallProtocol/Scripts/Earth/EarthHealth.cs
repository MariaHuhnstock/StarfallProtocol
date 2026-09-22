using UnityEngine;
using System;

public class EarthHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    public event Action<float> OnHealthChanged; // 0-1 für die Healthbar
    public event Action OnEarthDestroyed;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth = Mathf.Max(0, currentHealth - amount);
        OnHealthChanged?.Invoke((float)currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            OnEarthDestroyed?.Invoke();
        }
    }
}