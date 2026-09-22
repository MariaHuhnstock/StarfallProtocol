using StarfallProtocol.Player;

namespace StarfallProtocol.Upgrades
{
    public class SpeedUpgrade : IUpgradeEffect
    {
        private readonly float _amount;
        public SpeedUpgrade(float amount) { _amount = amount; }

        public void Apply(PlayerContext context)
        {
            context.Controller.AddMoveSpeedMultiplier(_amount);
        }
    }
}