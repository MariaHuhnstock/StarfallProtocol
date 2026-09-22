using UnityEngine;
using StarfallProtocol.Enemies;

public class EnemyEarthCollision : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EarthHealth>(out var earth))
        {
            Debug.Log($"{gameObject.name} hit earth");
            earth.TakeDamage(enemyData.earthDamage);
            gameObject.SetActive(false);
        }
    }
}