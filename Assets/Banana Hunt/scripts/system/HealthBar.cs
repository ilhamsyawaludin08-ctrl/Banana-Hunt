using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    [Header("UI References")]
    public Image fillImage;

    void Awake()
    {
        currentHealth = maxHealth;
        ApplyBar();
    }

    void ApplyBar()
    {
        if (fillImage != null)
            fillImage.fillAmount = (maxHealth > 0f) ? Mathf.Clamp01(currentHealth / maxHealth) : 0f;
    }

    public void SetHealth(float current)
    {
        currentHealth = Mathf.Clamp(current, 0f, maxHealth);
        ApplyBar();
    }
}
