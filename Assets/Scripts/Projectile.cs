using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;

    private void Start()
    {
        // Make the projectile move forward
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;
    }

    // This method is called when the projectile collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Instead of using collision.CompareTag, we should use collision.collider.CompareTag
        if (collision.collider.CompareTag("Player"))
        {
            // Handle the player being hit (deal damage, etc.)
            Debug.Log("Player hit!");

            // Destroy the projectile after hitting the player
            Destroy(gameObject);
        }
        else
        {
            // Destroy the projectile if it hits something other than the player
            Destroy(gameObject);
        }
    }
}
