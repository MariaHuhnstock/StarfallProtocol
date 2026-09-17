using UnityEngine;
using StarfallProtocol.Upgrades;

namespace StarfallProtocol.Player
{
    public class UpgradeInventory : MonoBehaviour
    {
        [SerializeField] private PlayerController _controller;
        [SerializeField] private PlayerShooting _shooting;
        [SerializeField] private PlayerHealth _health;

        private PlayerContext _context;

        private void Awake()
        {
            _context = new PlayerContext(_controller, _shooting, _health);
        }

        public void ApplyUpgrade(UpgradeData data)
        {
            IUpgradeEffect effect = data.CreateEffect();
            effect?.Apply(_context);
        }
    }
}