using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object to store the starting data of a battle encounter
/// </summary>
[CreateAssetMenu(fileName = "Battle Encounter", menuName = "Encounter/Encounters/Battle")]
public class Battle : Encounter
{
    [Header("Battle")]
    [Tooltip("Difficulty of the battle")]
    public Difficulty difficulty;
    [Tooltip("Enemies involved in the battle")]
    public Enemy[] enemies;
    [Tooltip("Enemy index / indices needed to be defeated in the battle")]
    public int[] winCondition;
    [Tooltip("Reward for the player after completing this encounter")]
    public Reward reward;

    public enum Difficulty
    {
        veryEasy,
        easy,
        medium,
        hard,
        veryHard
    };
}
