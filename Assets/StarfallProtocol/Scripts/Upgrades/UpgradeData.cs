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

        [Header("Effect Value")]
        [Tooltip("FireRate/Speed: prozentualer Bonus (0.15 = +15%). Shield: Anzahl Ladungen (abgerundet). DoubleShot: ungenutzt.")]
        public float value = 0.15f;

        public IUpgradeEffect CreateEffect()
        {
            switch (type)
            {
                case UpgradeType.FireRate: return new FireRateUpgrade(value);
                case UpgradeType.DoubleShot: return new DoubleShotUpgrade();
                case UpgradeType.Shield: return new ShieldUpgrade(Mathf.RoundToInt(value));
                case UpgradeType.Speed: return new SpeedUpgrade(value);
                default: return null;
            }
        }
    }
}