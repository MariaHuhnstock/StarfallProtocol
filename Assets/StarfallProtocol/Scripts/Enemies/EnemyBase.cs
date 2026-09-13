using StarfallProtocol.Weapons;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarfallProtocol.Core;

namespace StarfallProtocol.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private EnemyData _data;
        private int _currentHealth;
        private EnemyState _state;
        private IMovementPattern _movementPattern;
        private EnemyPool _ownerPool;

        public EnemyState CurrentState => _state;

        public void Init(EnemyData data, IMovementPattern movementPattern, EnemyPool ownerPool)
        {
            _data = data;
            _movementPattern = movementPattern;
            _ownerPool = ownerPool;
            _currentHealth = data.maxHealth;
            _state = EnemyState.Spawning;

            // Kurzer Spawn-Zustand, danach direkt Moving.
            _state = EnemyState.Moving;
        }

        private void Update()
        {
            if (_state == EnemyState.Moving)
            {
                _movementPattern.Move(transform, _data.moveSpeed, Time.deltaTime);
            }
        }

        public void TakeDamage(int amount)
        {
            if (_state == EnemyState.Dying) return;

            _currentHealth -= amount;
            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _state = EnemyState.Dying;
            ScoreManager.Instance?.AddScore(_data.scoreValue);
            _ownerPool.ReturnEnemy(this, _data.patternType);
        }

        private void OnBecameInvisible()
        {
            // Gegner, die den Bildschirm unten verlassen, zurück in den Pool statt Destroy.
            if (_state != EnemyState.Dying)
            {
                _ownerPool.ReturnEnemy(this, _data.patternType);
            }
        }
    }
}