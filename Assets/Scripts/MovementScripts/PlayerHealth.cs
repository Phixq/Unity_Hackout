using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Needed for UI stuff
using UnityEngine.SceneManagement; // (Optional) if you want to reload scene later

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;

    public GameObject gameOverScreen; // Drag your GameOver UI panel here in Inspector

    void Start()
    {
        health = maxHealth;

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false); // Hide Game Over screen at the start
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            playerSr.enabled = false;
            playerMovement.enabled = false;

            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true); // Show Game Over screen
            }
        }
    }
}
