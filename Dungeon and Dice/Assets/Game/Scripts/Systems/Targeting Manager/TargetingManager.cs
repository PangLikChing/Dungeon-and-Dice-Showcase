using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manager to handle all comunications between targeting system and Game Manager
/// </summary>
public class TargetingManager : Singleton<TargetingManager>
{
    [Tooltip("Raise when player targets a character")]
    public UnityEvent<Character> ChangeTarget;

    // Method to ask the UI manager to change the UI display for target marker
    public void InvokeChangeTarget(Transform transform)
    {
        try
        {
            ChangeTarget.Invoke(transform.GetComponent<Character>());
        }
        catch
        {
            // Throw a debug message
            Debug.Log($"{transform.name} does not have a Character component!");
        }
    }
}
