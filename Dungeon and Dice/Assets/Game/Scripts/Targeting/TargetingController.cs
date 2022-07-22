using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Script to control the targeting behaviour of the targeting system
/// </summary>
public class TargetingController : MonoBehaviour
{
    [Tooltip("Raise when the user clicked on a collider transform")]
    public UnityEvent<Transform> TryChangeTarget;

    void Update()
    {
        // If the user press the left mouse button, use new input system later
        if (Input.GetButtonDown("Fire1"))
        {
            // Try to target when the user is targeting
            TryTarget();
        }
    }

    // Method to try and target the a character
    private void TryTarget()
    {
        // Cast a ray from mouse position to game world
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        try
        {
            // If the ray hits something and it is a character
            if (hit.collider != null && hit.collider.GetComponent<Character>() != null)
            {
                // Cache the hit collider's transform
                Transform hitTransform = hit.collider.transform;

                // Throw a debug message
                Debug.Log("Target is: " + hitTransform.name);

                // Ask the UI Manager to display the targeting UI and the Game Manager to change target
                TryChangeTarget.Invoke(hitTransform);
            }
    }
        catch
        {
            // Throw a debug message
            Debug.Log("The hit object does not have a collider!");
        }
    }
}
