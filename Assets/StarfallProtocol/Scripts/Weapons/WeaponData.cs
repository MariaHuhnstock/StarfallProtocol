using UnityEngine;

namespace StarfallProtocol.Weapons
{
    [CreateAssetMenu(fileName = "NewWeaponData", menuName = "StarfallProtocol/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        [Header("Stats")]
        public float fireRate = 4f;
        public int damage = 1;
        public float projectileSpeed = 12f;

        [Header("References")]
        public Projectile projectilePrefab;
    }
}