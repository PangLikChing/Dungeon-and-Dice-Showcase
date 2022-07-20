using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for dice's behaviour
/// </summary>
[RequireComponent(typeof(Image), typeof(Animator))]
public class Dice : MonoBehaviour
{
    [Tooltip("The Animator of this die")]
    Animator animator;
    [Tooltip("Is this die rolling")]
    bool isRolling = false;
    [Tooltip("Timer for keeping track of when this die should change a side to display")]
    float changeSideTimePassed = 0.0f;

    [Tooltip("Should this die have a random face on start")]
    [SerializeField] bool randomStart = true;

    [Header("Data")]
    [Tooltip("Die size of this die")]
    [SerializeField] DieSize dieSize;
    [Tooltip("The number display's Image of this die")]
    [SerializeField] Image image;
    [Tooltip("How long will the result get rolled")]
    [SerializeField] float rollingTime = 0.0f;
    [Tooltip("How long will the face of the dice change during rolling")]
    [SerializeField] float changeSideTime = 0.0f;
    [Tooltip("All the faces of the die")]
    [SerializeField] Sprite[] faces;

    public enum DieSize
    {
        D4,
        D6,
        D8,
        D10,
        D12,
        D20
    };
    void Start()
    {
        // Initialize
        animator = GetComponent<Animator>();
        isRolling = false;

        // If the die should have a random starting face
        if (randomStart == true)
        {
            // If there are at least 1 face in faces
            try
            {
                // Randomize a face
                image.sprite = faces[Random.Range(0, faces.Length)];
            }
            catch
            {
                // Throw a debug message
                Debug.Log("There is no faces added");
            }
        }
    }

    void Update()
    {
        if (isRolling == true)
        {
            // If it is not time to change the side display yet
            if (changeSideTimePassed < changeSideTime)
            {
                // Increment the change side timer by real time passed
                changeSideTimePassed += Time.deltaTime;
            }
            // If it is time to change the side display
            else
            {
                // Change the sprite to a random sprite
                image.sprite = faces[Random.Range(0, faces.Length)];

                // Reset the change side timer
                changeSideTimePassed = 0;
            }
        }
    }

    // Method to roll the die
    public void RollDie()
    {
        // Roll the die
        StartCoroutine(Rolling());
    }

    private void GetRollResult()
    {
        // This result will have a minus 1 because there is no die with 0 on it
        int rollResult = Random.Range(0, faces.Length);

        // Throw a debug message
        Debug.Log($"The roll result is {rollResult + 1}");

        try
        {
            // Change the sprite to match the roll result
            image.sprite = faces[rollResult];
        }
        catch
        {
            // Throw a debug message
            Debug.Log("There is no sprite randerer on the die face prefeb!");
        }
    }

    IEnumerator Rolling()
    {
        // Start the rolling "animation"
        isRolling = true;
        animator.SetTrigger("Rolling");

        // Wait for the rolling time specified
        yield return new WaitForSeconds(rollingTime);

        // Stop rolling
        isRolling = false;
        animator.SetTrigger("Idle");
        transform.rotation = Quaternion.identity;

        // Get the result
        GetRollResult();
    }
}
