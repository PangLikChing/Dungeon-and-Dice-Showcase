using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base scriptable object for all encounters in the game
/// </summary>
public class Encounter : ScriptableObject
{
    [Header("Encounter")]
    [Tooltip("Reward for the player after completing this encounter")]
    public Reward reward;
}
