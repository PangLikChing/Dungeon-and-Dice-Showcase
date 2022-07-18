using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object that store all the stats on start for a character
/// </summary>
[CreateAssetMenu(fileName = "Character Stats", menuName = "Character/Stats")]
public class Stats : ScriptableObject
{
    [Header("Stats")]
    [Tooltip("Attack of the character")]
    public int attack = 0;
    [Tooltip("Maximum health of the character")]
    public int maximumHealth = 0;
}
