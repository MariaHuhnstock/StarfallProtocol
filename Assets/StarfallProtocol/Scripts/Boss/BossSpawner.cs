using UnityEngine;
using StarfallProtocol.Core;
using StarfallProtocol.Weapons;

namespace StarfallProtocol.Boss
{
    public class BossSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _bossPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _spawnDelaySeconds = 30f;
        [SerializeField] private ProjectilePool _bossProjectilePool;

        private bool _bossSpawned;

        private void Update()
        {
            if (_bossSpawned) return;
            if (GameManager.Instance == null) return;

            if (GameManager.Instance.RunTime >= _spawnDelaySeconds)
            {
                SpawnBoss();
            }
        }

        private void SpawnBoss()
        {
            _bossSpawned = true;
            GameObject bossObj = Instantiate(_bossPrefab, _spawnPoint.position, Quaternion.identity);

            BossController controller = bossObj.GetComponent<BossController>();
            controller.SetProjectilePool(_bossProjectilePool);
        }
    }
}