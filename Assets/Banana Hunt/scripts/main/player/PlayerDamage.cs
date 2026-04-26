using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damageAmount = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            HealthSystem health = FindObjectOfType<HealthSystem>();

            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }
        }
    }
}