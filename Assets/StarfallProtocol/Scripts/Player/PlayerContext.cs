namespace StarfallProtocol.Player
{
    public class PlayerContext
    {
        public PlayerController Controller { get; }
        public PlayerShooting Shooting { get; }
        public PlayerHealth Health { get; }

        public PlayerContext(PlayerController controller, PlayerShooting shooting, PlayerHealth health)
        {
            Controller = controller;
            Shooting = shooting;
            Health = health;
        }
    }
}