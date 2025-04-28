using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float smoothSpeed = 0.125f; // Camera movement smoothing
    public float yOffset = 5.4f; // Camera Y offset
    public LayerMask groundLayer; // Layer to detect ground
    public Transform groundCheck; // Empty GameObject for ground detection

    private bool isGrounded;
    private float fixedCameraY; // Stores the last grounded Y position

    private void Start()
    {
        if (player != null)
        {
            fixedCameraY = player.position.y + yOffset; // Set initial Y position
        }
    }

    private void LateUpdate()
    {
        if (player == null || groundCheck == null)
        {
            Debug.LogWarning("Player or GroundCheck is not assigned in the CameraFollow2D script!");
            return;
        }

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Update Y position only if the player is grounded
        if (isGrounded)
        {
            fixedCameraY = player.position.y + yOffset;
        }

        // Follow X position but keep the Y position locked while jumping
        Vector3 desiredPosition = new Vector3(player.position.x, fixedCameraY, -10f);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
