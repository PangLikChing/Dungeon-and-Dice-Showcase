using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to serve as a editor tool that monitors changes like a layout group
/// User is required to set their own pivot points for the objects
/// </summary>
[ExecuteInEditMode]
public class GridLayoutGroup2D : MonoBehaviour
{
    [Header("Data")]
    [Tooltip("Spacing between every child game object along the axis specified")]
    [SerializeField] float spacing = 0;
    [Tooltip("Axis that the game object should align with")]
    [SerializeField] Axis axis;

    private enum Axis
    {
        x,
        y
    };

    void Start()
    {
        // Change child game object's position
        PositionObjects();
    }

    void Update()
    {
        // Change child game object's position
        PositionObjects();
    }

    // Method to position all child game objects in the right coordinate
    private void PositionObjects()
    {
        // Initialize a temp float to keep track of the total distance of the child game objects
        float totalDistance = 0.0f;

        // If the game objects should go along the x-axis
        if (axis == Axis.x)
        {
            // For every child game object
            for (int i = 0; i < transform.childCount; i++)
            {
                // Reset its position
                transform.GetChild(i).position = Vector2.zero;

                // Calculate the new position for the game object
                transform.GetChild(i).position = new Vector2(transform.position.x + totalDistance + transform.GetChild(i).localScale.x / 2, transform.position.y + transform.GetChild(i).position.y);

                // Calculate how far should the next game object start from the origin
                totalDistance += transform.GetChild(i).localScale.x + spacing;
            }
        }
        // If the game objects should go along the y-axis
        if (axis == Axis.y)
        {
            // For every child game object
            for (int i = 0; i < transform.childCount; i++)
            {
                // Reset its position
                transform.GetChild(i).position = Vector2.zero;

                // Calculate the new position for the game object
                transform.GetChild(i).position = new Vector2(transform.position.x + transform.GetChild(i).position.x, transform.position.y + totalDistance + transform.GetChild(i).localScale.y / 2);

                // Calculate how far should the next game object start from the origin
                totalDistance += transform.GetChild(i).localScale.y + spacing;
            }
        }
    }
}
