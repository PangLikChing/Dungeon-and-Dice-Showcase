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
    [Tooltip("Which modifier does the skill associate with?")]
    public Stats.StatModifier modifier;
    [Tooltip("Which skill type does the skill belong to?")]
    public SkillType skillType;
    [Tooltip("Skill improvement in terms of damage for this skill")]
    public SkillLevel[] skillLevel;

    public enum SkillType
    {
        Melee,
        Ranged,
        Magic,
        Support
    }

    [System.Serializable]
    public struct SkillLevel
    {
        public int diceNumber;
        public DiceManager.DieSize dieSize;
    }

    // Method to execute the damaging skill
    public abstract void ExecuteSkill(Character source, Character target, int amount);
}
