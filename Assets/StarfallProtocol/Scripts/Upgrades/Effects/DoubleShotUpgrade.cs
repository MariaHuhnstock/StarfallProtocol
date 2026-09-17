using StarfallProtocol.Player;

namespace StarfallProtocol.Upgrades
{
    public class DoubleShotUpgrade : IUpgradeEffect
    {
        public void Apply(PlayerContext context)
        {
            context.Shooting.SetDoubleShot(true);
        }
    }
}