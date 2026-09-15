using UnityEngine;
using StarfallProtocol.Core;
using StarfallProtocol.Weapons;

namespace StarfallProtocol.Boss
{
    public class BossController : MonoBehaviour, IDamageable
    {
        [SerializeField] private BossData _data;
        [SerializeField] private Transform _firePoint;

        private ProjectilePool _bossProjectilePool;

        private int _currentHealth;
        private BossPhase _currentPhase;
        private float _fireTimer;
        private float _driftTimer;
        private Vector3 _startPosition;
        private Transform _playerTransform;

        public void SetProjectilePool(ProjectilePool pool)
        {
            _bossProjectilePool = pool;
        }

        private void Start()
        {
            _currentHealth = _data.maxHealth;
            _currentPhase = BossPhase.Entering;
            _startPosition = transform.position;

            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) _playerTransform = playerObj.transform;
        }

        private void Update()
        {
            switch (_currentPhase)
            {
                case BossPhase.Entering:
                    HandleEntering();
                    break;
                case BossPhase.Phase1:
                case BossPhase.Phase2:
                    HandleDrift();
                    HandleAttack();
                    break;
            }
        }

        private void HandleEntering()
        {
            transform.position += Vector3.down * _data.entrySpeed * Time.deltaTime;

            if (transform.position.y <= _data.stopYPosition)
            {
                Vector3 pos = transform.position;
                pos.y = _data.stopYPosition;
                transform.position = pos;
                _currentPhase = BossPhase.Phase1;
            }
        }

        private void HandleDrift()
        {
            _driftTimer += Time.deltaTime;
            float xOffset = Mathf.Sin(_driftTimer * _data.horizontalDriftSpeed) * _data.horizontalDriftRange;

            Vector3 pos = transform.position;
            pos.x = _startPosition.x + xOffset;
            transform.position = pos;
        }

        private void HandleAttack()
        {
            _fireTimer -= Time.deltaTime;
            if (_fireTimer <= 0f)
            {
                Shoot();
                float fireRate = _currentPhase == BossPhase.Phase1 ? _data.phase1FireRate : _data.phase2FireRate;
                _fireTimer = 1f / fireRate;
            }
        }

        private void Shoot()
        {
            if (_playerTransform == null || _bossProjectilePool == null) return;

            Vector3 direction = (_playerTransform.position - _firePoint.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

            float speed = _currentPhase == BossPhase.Phase1 ? _data.phase1ProjectileSpeed : _data.phase2ProjectileSpeed;
            int damage = _currentPhase == BossPhase.Phase1 ? _data.phase1Damage : _data.phase2Damage;

            _bossProjectilePool.SpawnProjectile(_firePoint.position, rotation, speed, damage);
        }

        public void TakeDamage(int amount)
        {
            if (_currentPhase == BossPhase.Dying) return;

            _currentHealth -= amount;
            float healthPercent = (float)_currentHealth / _data.maxHealth;

            if (_currentPhase == BossPhase.Phase1 && healthPercent <= _data.phaseThreshold)
            {
                _currentPhase = BossPhase.Phase2;
            }

            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _currentPhase = BossPhase.Dying;
            ScoreManager.Instance?.AddScore(_data.scoreValue);
            gameObject.SetActive(false);
        }
    }
}