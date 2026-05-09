using UnityEngine;
using UnityEngine.UI; // Optional: If you want to show health on UI

public class MainPlayerDie : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 3;
    private int currentHealth;

    [Header("UI References")]
    public GameObject endpanel;

    [Header("Settings")]
    [SerializeField] private string enemyTag = "Enemy";
    public float invincibilityDuration = 1.0f; // Time player is safe after being hit
    private float invincibilityTimer;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // Count down the invincibility timer
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag) && invincibilityTimer <= 0)
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player hit! Health remaining: " + currentHealth);

        // Trigger brief invincibility so one collision doesn't drain all health instantly
        invincibilityTimer = invincibilityDuration;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        endpanel.SetActive(true);
        Time.timeScale = 0f;
        gameObject.SetActive(false);
    }
}

