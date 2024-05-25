// AnimatorManager.cs
// Manages animator parameters for player movement by snapping input values and updating the animator accordingly.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Animator animator; // Reference to the Animator component
    int horizontal; // Hash value for the horizontal parameter in the animator controller
    int vertical; // Hash value for the vertical parameter in the animator controller

    private void Awake()
    {
        // Initialize references and hash values
        animator = GetComponent<Animator>(); // Retrieve the Animator component from the same GameObject
        horizontal = Animator.StringToHash("Horizontal"); // Get hash value for the "Horizontal" parameter
        vertical = Animator.StringToHash("Vertical"); // Get hash value for the "Vertical" parameter
    }

    // Updates the animator values based on player movement input
    public void updateAnimatorValues(float verticalMovement, float horizontalMovement)
    {
        float snappedHorizontal; // Snapped value for horizontal movement
        float snappedVertical; // Snapped value for vertical movement

        #region Snapped Horizontal
        // Determine snapped horizontal value based on horizontal movement input
        if(horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            snappedHorizontal = 0.5f;
        }
        else if(horizontalMovement > 0.55f)
        {
            snappedHorizontal = 1;
        }
        else if(horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            snappedHorizontal = -0.5f;
        }
        else if(horizontalMovement < -0.55f)
        {
            snappedHorizontal = -1;
        }
        else
        {
            snappedHorizontal = 0;
        }
        #endregion

        #region Snapped Vertical
        // Determine snapped vertical value based on vertical movement input
        if(verticalMovement > 0 && verticalMovement < 0.55f)
        {
            snappedVertical = 0.5f;
        }
        else if(verticalMovement > 0.55f)
        {
            snappedVertical = 1;
        }
        else if(verticalMovement < 0 && verticalMovement > -0.55f)
        {
            snappedVertical = -0.5f;
        }
        else if(verticalMovement < -0.55f)
        {
            snappedVertical = -1;
        }
        else
        {
            snappedVertical = 0;
        }
        #endregion

        // Update animator parameters with snapped values
        animator.SetFloat(horizontal, snappedHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);
    }
}
