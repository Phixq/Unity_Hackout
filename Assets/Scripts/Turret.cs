using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target; // The target for the turret (usually the player)
    public float rotationSpeed = 5f; // Speed at which the turret rotates
    public float fireRate = 1f; // Time between shots
    public GameObject projectilePrefab; // The projectile the turret will shoot
    public Transform firePoint; // The position from where the projectile will be fired
    public float shootingRange = 10f; // The range within which the turret will shoot at the player
    public LayerMask obstacleLayer; // Layer mask for obstacles that the turret cannot shoot through

    private float nextFireTime = 0f;

    private void Update()
    {
        if (target != null)
        {
            RotateTowardsTarget();

            // If the player is within the shooting range and the fire rate time has passed
            if (Vector2.Distance(transform.position, target.position) <= shootingRange && Time.time > nextFireTime)
            {
                // Perform raycasting to check if there's an obstacle between the turret and the player
                if (!IsObstacleBetweenTurretAndPlayer())
                {
                    Shoot();
                }
                else
                {
                    Debug.Log("There's an obstacle between the turret and the player.");
                }
            }
        }
    }

    void RotateTowardsTarget()
    {
        // Calculate the direction from the turret to the player
        Vector2 direction = (target.position - transform.position).normalized;

        // Calculate the rotation angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Smoothly rotate towards the player
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        nextFireTime = Time.time + fireRate; // Set the next time the turret can fire
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation); // Create a new projectile at the fire point
    }

    // Raycast to check if there is an obstacle between the turret and the player
    bool IsObstacleBetweenTurretAndPlayer()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootingRange, obstacleLayer);

        // If the ray hits something, there is an obstacle
        if (hit.collider != null)
        {
            return true; // There is an obstacle
        }
        return false; // No obstacle
    }
}
