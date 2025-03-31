using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;  // Player starts with 3 health
    public bool isDead = false;  // Tracks if the player is dead

    // Start is called once before the first execution of Update
    void Start()
    {
        // You can initialize any other things here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // If player health is 0 or below, mark as dead
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    // Method to take damage and reduce health
    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            health -= damage;  // Reduce health by the damage amount
            Debug.Log("Player health: " + health);  // Log current health

            // If health reaches 0 or below, die
            if (health <= 0)
            {
                health = 0;  // Ensure health doesn't go below 0
                Die();
            }
        }
    }

    // Method to handle player death
    void Die()
    {
        isDead = true;
        Debug.Log("Player is dead!");

        // Optionally, you can add animations, disable movement, etc.
        // For example, you can disable the player's movement or destroy the player object:
        // GetComponent<PlayerMovement>().enabled = false; // If you have a movement script
        // Destroy(gameObject);  // This will destroy the player object (for example purposes)
    }

    // Method to heal the player (you can add a healing feature if needed)
    public void Heal(int healAmount)
    {
        if (!isDead)
        {
            health += healAmount;
            health = Mathf.Min(health, 3);  // Ensure health doesn't exceed 3 (max health)
            Debug.Log("Player healed! Health: " + health);
        }
    }
}