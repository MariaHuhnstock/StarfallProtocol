using StarfallProtocol.Player;

namespace StarfallProtocol.Upgrades
{
    /// <summary>Erhöht die Feuerrate um 25% (stackt bei mehrfacher Auswahl).</summary>
    public class FireRateUpgrade : IUpgradeEffect
    {
        public void Apply(PlayerContext context)
        {
            context.Shooting.AddFireRateMultiplier(0.25f);
        }
    }
}