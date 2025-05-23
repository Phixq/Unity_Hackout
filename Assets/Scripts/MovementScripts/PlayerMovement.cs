using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // Movement speed of the player
    public float jumpForce = 10f;       // Jumping force
    public float jumpCooldown = 2f;     // Time in seconds between each jump
    public Transform groundCheck;       // Position to check if player is grounded
    public LayerMask groundLayer;       // Ground layer mask to check if player is on the ground

    private bool isGrounded;            // Is the player currently grounded?
    private bool canJump = true;        // Can the player jump (cooldown check)
    private float lastJumpTime;         // The time when the player last jumped
    private Rigidbody2D rb;             // Rigidbody2D component
    private Animator anim;

    private void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if the player is grounded (using a small circle to check below the player)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);


        Jump();
    }
    private void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        MovePlayer(moveInput);
    }

    // Handles player movement
    private void MovePlayer(float moveInput)
    {
        // Set the linear velocity of the player, only modifying the x-axis for horizontal movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        anim.SetFloat("Speed", moveInput);
        Debug.Log("set speed");
        Debug.Log(moveInput);

        // Flip and resize the player's sprite based on the direction of movement
        if (moveInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput) * 0.8f, 0.8f, 0.8f);  // Flip sprite & resize
        }
    }

    // Handles player jumping with cooldown
    private void Jump()
    {
        // Check if the player presses the jump button and is grounded, and if cooldown has passed
        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            // Apply an upward force for the jump using AddForce to ensure gravity works correctly
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // Set the cooldown flag to false and record the time of the jump
            canJump = false;
            lastJumpTime = Time.time;
        }

        // If enough time has passed (jumpCooldown), allow the player to jump again
        if (!canJump && Time.time - lastJumpTime >= jumpCooldown)
        {
            canJump = true; // Allow jumping again
        }
    }
}
