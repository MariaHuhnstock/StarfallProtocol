using UnityEngine;

public class EnemyEarthCollision : MonoBehaviour
{
    [SerializeField] private int damageToEarth = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EarthHealth>(out var earth))
        {
            earth.TakeDamage(damageToEarth);
            // zurück ins Object Pool statt Destroy(), passend zu eurem System
            gameObject.SetActive(false);
        }
    }
}