using UnityEngine;

namespace StarfallProtocol.Upgrades
{
    public enum UpgradeType
    {
        FireRate,
        DoubleShot,
        Shield,
        Speed
    }

    [CreateAssetMenu(fileName = "NewUpgradeData", menuName = "StarfallProtocol/Upgrade Data")]
    public class UpgradeData : ScriptableObject
    {
        public UpgradeType type;
        public string displayName;
        [TextArea] public string description;
        public Sprite icon;

        [Tooltip("Falls deaktiviert, kann dieses Upgrade nur einmal ausgewählt werden.")]
        public bool isStackable = true;

        public IUpgradeEffect CreateEffect()
        {
            switch (type)
            {
                case UpgradeType.FireRate: return new FireRateUpgrade();
                case UpgradeType.DoubleShot: return new DoubleShotUpgrade();
                case UpgradeType.Shield: return new ShieldUpgrade();
                case UpgradeType.Speed: return new SpeedUpgrade();
                default: return null;
            }
        }
    }
}