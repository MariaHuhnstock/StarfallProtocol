using UnityEngine;

namespace StarfallProtocol.Boss
{
    [CreateAssetMenu(fileName = "NewBossData", menuName = "StarfallProtocol/Boss Data")]
    public class BossData : ScriptableObject
    {
        [Header("Stats")]
        public int maxHealth = 60;
        public int scoreValue = 500;

        [Range(0.1f, 0.9f)]
        [Tooltip("Prozentualer Health-Anteil, bei dem Phase 2 startet.")]
        public float phaseThreshold = 0.5f;

        [Header("Movement")]
        public float entrySpeed = 1.5f;
        [Tooltip("Y-Position, an der der Boss stehen bleibt.")]
        public float stopYPosition = 3f;
        public float horizontalDriftSpeed = 0.5f;
        public float horizontalDriftRange = 2f;

        [Header("Phase 1 Attack")]
        public float phase1FireRate = 0.5f; // Schüsse pro Sekunde
        public float phase1ProjectileSpeed = 6f;
        public int phase1Damage = 1;

        [Header("Phase 2 Attack")]
        public float phase2FireRate = 1.2f;
        public float phase2ProjectileSpeed = 8f;
        public int phase2Damage = 1;
    }
}