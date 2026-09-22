using StarfallProtocol.Player;

namespace StarfallProtocol.Upgrades
{
    public class FireRateUpgrade : IUpgradeEffect
    {
        private readonly float _amount;
        public FireRateUpgrade(float amount) { _amount = amount; }

        public void Apply(PlayerContext context)
        {
            context.Shooting.AddFireRateMultiplier(_amount);
        }
    }
}