using UnityEngine;

namespace StarfallProtocol.Enemies
{
    /// <summary>Bewegt sich nach unten in einer Sinuskurve seitlich.</summary>
    public class WeaverMovement : IMovementPattern
    {
        private float _timeAlive;
        private readonly float _amplitude = 2f;
        private readonly float _frequency = 2f;

        public void Move(Transform enemyTransform, float speed, float deltaTime)
        {
            _timeAlive += deltaTime;

            Vector3 pos = enemyTransform.position;
            pos.y -= speed * deltaTime;
            pos.x += Mathf.Sin(_timeAlive * _frequency) * _amplitude * deltaTime;

            enemyTransform.position = pos;
        }
    }
}