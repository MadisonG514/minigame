using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed of movement
    public float moveSpeed = 5f;
    // Dimentions of restricted box
    public float minX = -5f;
    public float maxX = 5f;
    public float minZ = -5f;
    public float maxZ = 5f;

     public GameObject projectilePrefab;

    // last movement direction
    [HideInInspector] public Vector3 lastMovementDirection;

    void Update()
    {
        // Get the input for movement (WASD keys)
        float moveX = Input.GetAxisRaw("Horizontal"); // A, D or Left Arrow, Right Arrow
        float moveZ = Input.GetAxisRaw("Vertical");   // W, S or Up Arrow, Down Arrow

        // Create a movement vector
        Vector3 movementDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Update last movement direction
        if (movementDirection.magnitude > 0)
        {
            lastMovementDirection = movementDirection; // Update last direction only when moving

            // Move the player in the direction of movement
            transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);
            RotatePlayer(movementDirection); // Rotate the player based on movement direction
        }
         if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch object from player
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
        {  
            // player's position within the defined bounds
            Vector3 currentPosition = transform.position;
            currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
            currentPosition.z = Mathf.Clamp(currentPosition.z, minZ, maxZ);

            // player's position update
            transform.position = currentPosition;
        }
    }

    void RotatePlayer(Vector3 direction)
    {
        // Calculate the angle based on the movement direction
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Apply the rotation around the Y-axis
        transform.rotation = Quaternion.Euler(new Vector3(0, targetAngle, 0));
        //I hate and love coding
    }
}