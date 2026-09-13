using UnityEngine;
using StarfallProtocol.Pooling;

namespace StarfallProtocol.Weapons
{
    public class ProjectilePool : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private int _initialSize = 20;

        private ObjectPool<Projectile> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<Projectile>(_projectilePrefab, transform, _initialSize);
        }

        public Projectile SpawnProjectile(Vector3 position, Quaternion rotation, float speed, int damage)
        {
            Projectile projectile = _pool.Get(position, rotation);
            projectile.Init(speed, damage, this);
            return projectile;
        }

        public void ReturnToPool(Projectile projectile)
        {
            _pool.ReturnToPool(projectile);
        }
    }
}