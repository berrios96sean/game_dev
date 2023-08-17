using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    private Transform playerTransform; // Reference to the player's transform
    private Player playerMovement; // Reference to the script controlling player movement

    private void Start()
    {
        playerTransform = transform; // Assign the player's transform
        playerMovement = GetComponent<Player>(); // Assign the player's movement script
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Get the direction the player is facing from the movement script
        Vector2 shootDirection = playerMovement.GetFacingDirection(); // Modify this to your movement script's method

        // Apply force in the direction the player is facing
        rb.AddForce(shootDirection * bulletForce, ForceMode2D.Impulse);
    }
}
