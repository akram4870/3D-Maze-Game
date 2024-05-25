// PlayerManager.cs
// Manages player input and movement by delegating input handling to InputManager
// and movement control to PlayerLocomotion.


using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager; 
    PlayerLocomotion playerLocomotion; 
    private void Awake()
    {
        // Initialize references to required components
        inputManager = GetComponent<InputManager>(); // Retrieve the InputManager component from the same GameObject
        playerLocomotion = GetComponent<PlayerLocomotion>(); // Retrieve the PlayerLocomotion component from the same GameObject
    }

    private void Update()
    {
        inputManager.HandleAllInputs(); // Update input handling each frame
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement(); // Update movement handling in fixed intervals for smooth physics-based movement
    }
}
