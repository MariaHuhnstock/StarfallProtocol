using UnityEngine;
using StarfallProtocol.Player;

namespace StarfallProtocol.Enemies
{
    public class EnemyPlayerCollision : MonoBehaviour
    {
        [SerializeField] private int contactDamage = 1;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log($"{gameObject.name} hit player");
            if (other.TryGetComponent<PlayerHealth>(out var player))
            {
                player.TakeDamage(contactDamage);
                gameObject.SetActive(false); // zurück ins Object Pool
            }
        }
    }
}