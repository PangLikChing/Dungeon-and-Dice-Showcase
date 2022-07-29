using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object that store all the stats on start for a enemy character
/// </summary>
[CreateAssetMenu(fileName = "Character Stats", menuName = "Character/Enemy Stats")]
public class EnemyStats : Stats
{
    [Header("Enemy Stats")]
    [Tooltip("Attack of the character")]
    public int attack = 0;
}
