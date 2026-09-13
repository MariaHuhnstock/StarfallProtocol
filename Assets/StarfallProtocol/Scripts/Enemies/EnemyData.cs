using UnityEngine;

namespace StarfallProtocol.Enemies
{
    [CreateAssetMenu(fileName = "NewEnemyData", menuName = "StarfallProtocol/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [Header("Stats")]
        public int maxHealth = 3;
        public float moveSpeed = 2f;
        public int scoreValue = 10;

        [Header("Movement Pattern")]
        [Tooltip("Muss den Namen einer MovementPattern-Klasse referenzieren, z. B. 'Drifter'.")]
        public MovementPatternType patternType;
    }

    public enum MovementPatternType
    {
        Drifter,
        Weaver,
        Rusher
    }
}