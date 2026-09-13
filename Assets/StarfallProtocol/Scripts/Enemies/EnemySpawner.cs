using UnityEngine;
using StarfallProtocol.Core;

namespace StarfallProtocol.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private float _minX = -3.5f;
        [SerializeField] private float _maxX = 3.5f;
        [SerializeField] private float _spawnY = 6f;

        [Header("Difficulty Scaling")]
        [SerializeField] private float _startSpawnInterval = 1.5f;
        [SerializeField] private float _minSpawnInterval = 0.4f;
        [SerializeField] private float _difficultyRampDuration = 180f; // Sekunden bis Minimum erreicht ist

        private float _spawnTimer;

        private void Update()
        {
            _spawnTimer -= Time.deltaTime;

            if (_spawnTimer <= 0f)
            {
                SpawnRandomEnemy();
                _spawnTimer = GetCurrentSpawnInterval();
            }
        }

        private float GetCurrentSpawnInterval()
        {
            float runTime = GameManager.Instance != null ? GameManager.Instance.RunTime : 0f;
            float t = Mathf.Clamp01(runTime / _difficultyRampDuration);
            return Mathf.Lerp(_startSpawnInterval, _minSpawnInterval, t);
        }

        private void SpawnRandomEnemy()
        {
            MovementPatternType type = (MovementPatternType)Random.Range(0, 3);
            float x = Random.Range(_minX, _maxX);
            Vector3 spawnPos = new Vector3(x, _spawnY, 0f);

            _enemyPool.SpawnEnemy(type, spawnPos);
        }
    }
}