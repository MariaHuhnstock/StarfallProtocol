using UnityEngine;

namespace StarfallProtocol.Enemies
{
    /// <summary>Bewegt sich gerade nach unten.</summary>
    public class DrifterMovement : IMovementPattern
    {
        public void Move(Transform enemyTransform, float speed, float deltaTime)
        {
            enemyTransform.position += Vector3.down * speed * deltaTime;
        }
    }
}