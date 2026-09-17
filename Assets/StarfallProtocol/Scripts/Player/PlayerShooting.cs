using UnityEngine;
using StarfallProtocol.Weapons;

namespace StarfallProtocol.Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;
        [SerializeField] private ProjectilePool _projectilePool;

        [Header("Fire Points")]
        [SerializeField] private Transform _centerFirePoint;
        [SerializeField] private Transform _leftFirePoint;
        [SerializeField] private Transform _rightFirePoint;

        private float _fireTimer;
        private bool _doubleShotActive;
        private float _fireRateMultiplier = 1f;

        private void Update()
        {
            _fireTimer -= Time.deltaTime;

            if (Input.GetButton("Fire1") && _fireTimer <= 0f)
            {
                Shoot();
                _fireTimer = 1f / (_weaponData.fireRate * _fireRateMultiplier);
            }
        }

        private void Shoot()
        {
            if (_doubleShotActive)
            {
                FireFrom(_leftFirePoint);
                FireFrom(_rightFirePoint);
            }
            else
            {
                FireFrom(_centerFirePoint);
            }
        }

        private void FireFrom(Transform point)
        {
            _projectilePool.SpawnProjectile(
                point.position,
                point.rotation,
                _weaponData.projectileSpeed,
                _weaponData.damage
            );
        }

        public void SetDoubleShot(bool active)
        {
            _doubleShotActive = active;
        }

        public void AddFireRateMultiplier(float amount)
        {
            _fireRateMultiplier += amount;
        }
    }
}