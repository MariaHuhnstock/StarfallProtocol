using StarfallProtocol.Player;

namespace StarfallProtocol.Upgrades
{
    /// <summary>Erhöht die Bewegungsgeschwindigkeit um 15% (stackt).</summary>
    public class SpeedUpgrade : IUpgradeEffect
    {
        public void Apply(PlayerContext context)
        {
            context.Controller.AddMoveSpeedMultiplier(0.15f);
        }
    }
}