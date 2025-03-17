using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;  // The damage the projectile deals
    public float speed = 10f;  // Speed at which the projectile travels
    public float lifetime = 5f;  // Time after which the projectile will be destroyed

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);  // Destroy the projectile after its lifetime ends
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile forward
        rb.linearVelocity = transform.right * speed;
    }

    // Collision detection when the projectile hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the projectile hit the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the player's health component and apply damage
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);  // Apply damage to the player
            }

            Destroy(gameObject);  // Destroy the projectile after hitting the player
        }
        else
        {
            // If the projectile hits anything other than the player, destroy it
            Destroy(gameObject);
        }
    }
}