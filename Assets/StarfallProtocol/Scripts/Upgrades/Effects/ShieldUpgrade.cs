using StarfallProtocol.Player;

namespace StarfallProtocol.Upgrades
{
    /// <summary>Gibt dem Spieler einen zusätzlichen Schild-Treffer, der Schaden absorbiert.</summary>
    public class ShieldUpgrade : IUpgradeEffect
    {
        public void Apply(PlayerContext context)
        {
            context.Health.AddShield(1);
        }
    }
}