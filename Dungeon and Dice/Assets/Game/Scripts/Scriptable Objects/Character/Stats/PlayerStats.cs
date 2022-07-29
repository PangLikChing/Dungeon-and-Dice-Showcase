using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object that store all the stats on start for a player character
/// </summary>
[CreateAssetMenu(fileName = "Player Stats", menuName = "Character/Player Stats")]
public class PlayerStats : Stats
{
    [Header("Player Stats")]
    [Tooltip("The class / job for the player")]
    public Job job;
    [Tooltip("Current skill set selected by the player")]
    public SkillData[] selectedSkills;
}
