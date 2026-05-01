using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damageAmount = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        HealthSystem health = FindObjectOfType<HealthSystem>();

        if (health == null) return;

        // Kena musuh = damage 20
        if (other.CompareTag("Enemy"))
        {
            health.TakeDamage(damageAmount);
        }

        // Kena air = langsung mati
        if (other.CompareTag("Water"))
        {
            health.TakeDamage(999);
        }
    }
}