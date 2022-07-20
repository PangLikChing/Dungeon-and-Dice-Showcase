using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable objects that holds the starting data of a skill
/// </summary>
[CreateAssetMenu(fileName = "Skill Data", menuName = "Skill/Skill Data")]
public class SkillData : ScriptableObject
{
    [Header("Data")]
    [Tooltip("Name of the skill")]
    public string skillName = "";
    [Tooltip("Skill improvement in terms of damage for this skill")]
    public SkillLevel[] skillLevel;

    [System.Serializable]
    public struct SkillLevel
    {
        public int diceNumber;
        public Dice.DieSize dieSize;
    }
}
