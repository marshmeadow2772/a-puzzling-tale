using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 3; // Maximum health of the character
    private int currentHealth;

    public float knockbackForce = 5f; // Force of the knockback
    public float flashDuration = 0.1f; // Duration for the red flash effect
    public SpriteRenderer spriteRenderer; // Reference to the character's sprite renderer

    private bool isInvulnerable = false; // Prevents multiple hits at once

    private void Start()
    {
        currentHealth = maxHealth;
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(Vector2 attackDirection)
    {
        if (isInvulnerable || currentHealth <= 0)
            return;

        currentHealth--;
        StartCoroutine(HandleKnockbackAndDamage(attackDirection));

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private System.Collections.IEnumerator HandleKnockbackAndDamage(Vector2 attackDirection)
    {
        isInvulnerable = true;

        // Apply knockback 3 times
        for (int i = 0; i < 3; i++)
        {
            // Apply knockback force
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero; // Reset velocity
                rb.AddForce(attackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
            }

            // Flash red
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.red;
                yield return new WaitForSeconds(flashDuration);
                spriteRenderer.color = Color.white;
            }

            yield return new WaitForSeconds(0.1f); // Small delay between knockbacks
        }

        isInvulnerable = false;
    }

    private void Die()
    {
        // Logic for character death
        Debug.Log("Character has died.");
        gameObject.SetActive(false); // Temporarily disables the character
    }
}