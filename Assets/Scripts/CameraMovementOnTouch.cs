using UnityEngine;


public class CameraMovementOnTouch : MonoBehaviour
{
    // Set the target position (x and y only, the z will remain unchanged)
    public Vector3 targetPosition = new Vector3(5f, 3f, 0f);  // Example: x = 5, y = 3, z = 0

    // This method will be called when another collider enters the trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided is the player (you can modify this check based on your game)
        if (other.CompareTag("Player"))
        {
            // Move the camera to the target position, keeping the current z value unchanged
            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        }
    }
}
