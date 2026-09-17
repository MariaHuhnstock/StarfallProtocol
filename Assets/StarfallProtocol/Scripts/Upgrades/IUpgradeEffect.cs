using StarfallProtocol.Player;

namespace StarfallProtocol.Upgrades
{
    public interface IUpgradeEffect
    {
        void Apply(PlayerContext context);
    }
}