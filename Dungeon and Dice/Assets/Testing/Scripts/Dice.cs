using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for dice's behaviour
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class Dice : MonoBehaviour
{
    [Tooltip("The Sprite Renderer of this die")]
    SpriteRenderer spriteRenderer;

    [Tooltip("All the faces of the die")]
    [SerializeField] Transform[] faces;

    void Start()
    {
        // Initialize
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Method to roll the die
    public void RollDie()
    {
        // Roll the die and get the result
        // This result will have a minus 1 because there is no die with 0 on it
        int rollResult = Random.Range(0, faces.Length);

        // Throw a debug message
        Debug.Log($"The roll result is {rollResult + 1}");

        try
        {
            // Change the sprite to match the roll result
            spriteRenderer.sprite = faces[rollResult].GetChild(0).GetComponent<SpriteRenderer>().sprite;
        }
        catch
        {
            // Throw a debug message
            Debug.Log("There is no sprite randerer on the die face prefeb!");
        }
    }
}
