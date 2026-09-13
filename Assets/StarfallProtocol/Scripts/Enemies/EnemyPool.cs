using UnityEngine;
using StarfallProtocol.Pooling;

namespace StarfallProtocol.Enemies
{
    public class EnemyPool : MonoBehaviour
    {
        [System.Serializable]
        public class EnemyPoolEntry
        {
            public EnemyData data;
            public EnemyBase prefab;
            public int initialSize = 5;
        }

        [SerializeField] private EnemyPoolEntry[] _enemyEntries;

        private readonly System.Collections.Generic.Dictionary<MovementPatternType, ObjectPool<EnemyBase>> _pools
            = new System.Collections.Generic.Dictionary<MovementPatternType, ObjectPool<EnemyBase>>();

        private readonly System.Collections.Generic.Dictionary<MovementPatternType, EnemyData> _dataLookup
            = new System.Collections.Generic.Dictionary<MovementPatternType, EnemyData>();

        private void Awake()
        {
            foreach (var entry in _enemyEntries)
            {
                var pool = new ObjectPool<EnemyBase>(entry.prefab, transform, entry.initialSize);
                _pools[entry.data.patternType] = pool;
                _dataLookup[entry.data.patternType] = entry.data;
            }
        }

        public EnemyBase SpawnEnemy(MovementPatternType type, Vector3 position)
        {
            EnemyData data = _dataLookup[type];
            EnemyBase enemy = _pools[type].Get(position, Quaternion.identity);

            IMovementPattern pattern = CreatePattern(type);
            enemy.Init(data, pattern, this);

            return enemy;
        }

        public void ReturnEnemy(EnemyBase enemy, MovementPatternType type)
        {
            _pools[type].ReturnToPool(enemy);
        }

        private IMovementPattern CreatePattern(MovementPatternType type)
        {
            switch (type)
            {
                case MovementPatternType.Drifter: return new DrifterMovement();
                case MovementPatternType.Weaver: return new WeaverMovement();
                case MovementPatternType.Rusher: return new RusherMovement();
                default: return new DrifterMovement();
            }
        }
    }
}