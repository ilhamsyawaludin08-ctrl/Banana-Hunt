using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;
    private float currentHealth;

    void Awake()
    {
        currentHealth = 100f;
    }

    void Start()
    {
        float max = (healthBar != null) ? healthBar.maxHealth : 100f;
        if (max <= 0f) max = 100f;
        currentHealth = max;

        if (healthBar != null)
            healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        float max = (healthBar != null) ? healthBar.maxHealth : 100f;
        if (max <= 0f) max = 100f;
        currentHealth = Mathf.Clamp(currentHealth, 0f, max);

        if (healthBar != null)
            healthBar.SetHealth(currentHealth);

        Debug.Log("[PlayerHealth] TakeDamage " + amount + " -> " + currentHealth);

        if (currentHealth <= 0f)
            OnDead();
    }

    public float GetCurrentHealth() { return currentHealth; }

    void OnDead()
    {
        Debug.Log("Player mati!");
    }
}
