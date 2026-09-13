using UnityEngine;

namespace StarfallProtocol.Enemies
{
    /// <summary>Bewegt sich schnell und gerade nach unten (rammt den Spieler).</summary>
    public class RusherMovement : IMovementPattern
    {
        private readonly float _speedMultiplier = 1.8f;

        public void Move(Transform enemyTransform, float speed, float deltaTime)
        {
            enemyTransform.position += Vector3.down * speed * _speedMultiplier * deltaTime;
        }
    }
}