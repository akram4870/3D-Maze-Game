// InputManager.cs
// This script handles player input using the PlayerControls input system.
// It retrieves movement input, processes it, and updates the AnimatorManager to reflect the player's movement state.


using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;

    AnimatorManager animatorManager;

    public Vector2 movementInput; // Stores the movement input values from the player

    public float verticalInput; // Stores the vertical movement input
    public float moveAmount; // Stores the magnitude of movement input
    public float horizontalInput; // Stores the horizontal movement input

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
    }
    // Called when the script becomes enabled and active
    private void OnEnable()
    {
        // Check if playerControls is null, and if so, initialize it and set up input actions
        if(playerControls == null)
        {
            playerControls = new PlayerControls();
            // Set up a listener for the Movement action, updating movementInput when performed
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        playerControls.Enable();
    }
    private void OnDisable()

    {
        playerControls.Disable();
    }
    public void HandleAllInputs()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y; // Get the vertical component of the movement input
        horizontalInput = movementInput.x; // Get the horizontal component of the movement input

        // Calculate the magnitude of movement input and clamp it between 0 and 1
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        // Update the animator values with the move amount to control animations
        animatorManager.updateAnimatorValues(0,moveAmount);
    }
}
