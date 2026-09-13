using UnityEngine;

namespace StarfallProtocol.Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        private float _speed;
        private int _damage;
        private ProjectilePool _ownerPool;
        private Rigidbody2D _rb;

        [SerializeField] private float _lifetimeSeconds = 3f;
        private float _lifetimeTimer;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Init(float speed, int damage, ProjectilePool ownerPool)
        {
            _speed = speed;
            _damage = damage;
            _ownerPool = ownerPool;
            _lifetimeTimer = 0f;

            _rb.linearVelocity = transform.up * _speed;
        }

        private void Update()
        {
            _lifetimeTimer += Time.deltaTime;
            if (_lifetimeTimer >= _lifetimeSeconds)
            {
                ReturnToPool();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(_damage);
                ReturnToPool();
            }
        }

        private void ReturnToPool()
        {
            _rb.linearVelocity = Vector2.zero;
            _ownerPool.ReturnToPool(this);
        }
    }
}