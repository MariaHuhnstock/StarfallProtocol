using System;
using UnityEngine;
using StarfallProtocol.Weapons;
using StarfallProtocol.Core;

namespace StarfallProtocol.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth = 5;

        private int _currentHealth;
        private int _shieldCharges;

        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;
        public int ShieldCharges => _shieldCharges;

        public event Action<float> OnHealthChanged;

        private void Awake()
        {
            _currentHealth = _maxHealth;
            OnHealthChanged?.Invoke((float)_currentHealth / _maxHealth);
        }

        public void TakeDamage(int amount)
        {
            if (_shieldCharges > 0)
            {
                _shieldCharges--;
                return;
            }

            _currentHealth -= amount;
            OnHealthChanged?.Invoke((float)_currentHealth / _maxHealth);

            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        public void AddShield(int amount)
        {
            _shieldCharges += amount;
        }

        private void Die()
        {
            GameManager.Instance?.TriggerGameOver();
        }
    }
}