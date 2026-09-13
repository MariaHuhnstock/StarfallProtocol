using UnityEngine;
using StarfallProtocol.Weapons;
using StarfallProtocol.Core;

namespace StarfallProtocol.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth = 5;

        private int _currentHealth;

        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;

            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            // GameManager wird das im nächsten Schritt abfangen und Game Over auslösen.
            GameManager.Instance?.TriggerGameOver();
        }
    }
}