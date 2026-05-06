using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Image healthFill;

    public float maxHealth = 100f;
    float currentHealth;

    public GameObject gameOver;

    private PlayerHitEffect playerHitEffect;


    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealth();

        playerHitEffect = GetComponent<PlayerHitEffect>();

        // 🔥 pastikan GameOver benar-benar mati di awal
        if (gameOver != null)
            gameOver.SetActive(false);

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;
        Debug.Log("HP sekarang: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            UpdateHealth();
            GameOver();
            return;
        }

          if (playerHitEffect != null)
        {
            playerHitEffect.PlayHitEffect();
        }

        UpdateHealth();
    }

    void UpdateHealth()
    {
        if (healthFill != null)
        {
            healthFill.fillAmount = currentHealth / maxHealth;
        }
    }

    void GameOver()
    {
        Debug.Log("🔥 GAME OVER KEPAKE");

        if (gameOver == null)
        {
            Debug.LogError("❌ GameOver belum di-assign di Inspector!");
            return;
        }

        // 🔥 RESET TIME dulu (biar UI gak ke-block aneh)
        Time.timeScale = 1f;

        // 🔥 aktifkan UI
        gameOver.SetActive(true);

        // 🔥 pastikan UI langsung refresh
        Canvas.ForceUpdateCanvases();

        // 🔥 baru pause game
        Time.timeScale = 0f;
    }
}