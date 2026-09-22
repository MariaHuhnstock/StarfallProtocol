using StarfallProtocol.Player;

namespace StarfallProtocol.Upgrades
{
    public class ShieldUpgrade : IUpgradeEffect
    {
        private readonly int _amount;
        public ShieldUpgrade(int amount) { _amount = amount; }

        public void Apply(PlayerContext context)
        {
            context.Health.AddShield(_amount);
        }
    }
}