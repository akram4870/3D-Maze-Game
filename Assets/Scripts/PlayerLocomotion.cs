/*
 * PlayerLocomotion.cs
 * 
 * Description:
 * Manages player movement and rotation based on input and camera orientation.
 */

using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;

    Vector3 moveDirection; // Direction in which the player will move
    Transform cameraObject;  // Reference to the main camera's transform
    
    Rigidbody playerRigidbody; // Reference to the player's Rigidbody component for physics-based movement

    public float movementSpeed = 7; // Speed at which the player moves

    public float rotationSpeed = 15; // Speed at which the player rotates

    private void Awake()
    {
        inputManager = GetComponent<InputManager>(); // Retrieve the InputManager component from the same GameObject
        playerRigidbody = GetComponent<Rigidbody>();    // Retrieve the Rigidbody component from the same GameObject
        cameraObject = Camera.main.transform; // Moved here to ensure it's assigned before use
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    // Calculates and applies movement based on player input and camera orientation.
    private void HandleMovement()
    {
        // Determine movement direction based on the camera's forward and right vectors, scaled by input
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection += cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize(); // Normalize the direction to ensure consistent movement speed
        moveDirection.y = 0; // Ensure movement is horizontal by nullifying vertical component
        moveDirection = moveDirection * movementSpeed; // Scale the movement direction by the movement speed

         // Apply the calculated movement direction to the player's Rigidbody velocity
        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity;
    }

// Calculates and applies rotation based on player input and camera orientation.
    private void HandleRotation()
    {
        // Calculate target direction based on the camera's forward and right vectors, scaled by input
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection += cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0; // Ensure rotation is horizontal by nullifying vertical component

        if (targetDirection == Vector3.zero) return; // Ensure there is a direction to face

        // Calculate the target rotation based on the target direction
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        // Smoothly interpolate between the current rotation and the target rotation
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Apply the interpolated rotation to the player's transform
        transform.rotation = playerRotation;
    }
}
