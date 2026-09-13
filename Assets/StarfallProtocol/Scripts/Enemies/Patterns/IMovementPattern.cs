using UnityEngine;

namespace StarfallProtocol.Enemies
{
    /// <summary>
    /// Interface für Bewegungsmuster. EnemyBase kennt nur diese Schnittstelle,
    /// nicht die konkrete Pattern-Klasse dahinter.
    /// </summary>
    public interface IMovementPattern
    {
        void Move(Transform enemyTransform, float speed, float deltaTime);
    }
}