using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    public float timer;
    private GameObject player;

    public float shootingRange = 5f; // New: made the distance configurable

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if (distance < shootingRange)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    // Draw the shooting range in the Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // Red for enemy range
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
