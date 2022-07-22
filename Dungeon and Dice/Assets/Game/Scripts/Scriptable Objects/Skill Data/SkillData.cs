using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base scriptable object that holds the starting data of a skill
/// </summary>
public abstract class SkillData : ScriptableObject
{
    [Header("Data")]
    [Tooltip("Name of the skill")]
    public string skillName = "";
    [Tooltip("Is the skill an AOE?")]
    public bool isAOE = false;
    [Tooltip("Skill improvement in terms of damage for this skill")]
    public SkillLevel[] skillLevel;

    // Method to execute the damaging skill
    public abstract void ExecuteSkill(Character source, Character target, int amount);

    [System.Serializable]
    public struct SkillLevel
    {
        public int diceNumber;
        public Dice.DieSize dieSize;
    }
}
