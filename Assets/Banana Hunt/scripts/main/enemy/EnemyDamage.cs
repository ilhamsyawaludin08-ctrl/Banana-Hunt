using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damageAmount = 20f;
    public float damageCooldown = 1f;
    private float lastDamageTime = -10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        TryDamage(other);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        TryDamage(other);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        TryDamage(col.collider);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        TryDamage(col.collider);
    }

    void TryDamage(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (Time.time - lastDamageTime < damageCooldown) return;

        PlayerHealth ph = other.GetComponent<PlayerHealth>();
        if (ph == null) return;

        lastDamageTime = Time.time;
        ph.TakeDamage(damageAmount);
        Debug.Log(gameObject.name + " kena damage " + damageAmount + " ke player. Health: " + ph.GetCurrentHealth());
    }
}
