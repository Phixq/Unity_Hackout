using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public float climbSpeed = 3f;
    private bool isClimbing = false;
    private float originalGravity;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
    }

    void Update()
    {
        if (isClimbing)
        {
            float verticalInput = Input.GetAxisRaw("Vertical");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, verticalInput * climbSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Stop falling when you grab the ladder
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.gravityScale = originalGravity;
        }
    }
}
