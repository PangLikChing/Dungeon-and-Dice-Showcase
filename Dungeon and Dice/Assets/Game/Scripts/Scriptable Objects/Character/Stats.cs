using Project.Build.Commands;
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
    [Tooltip("Type of the character, aka what element does the character belong to")]
    public SkillData.SkillType type;
    [Tooltip("Stat modifiers of the character")]
    public CharacterStat[] characterStat = new CharacterStat[4];

    [System.Serializable]
    public struct CharacterStat
    {
        [ReadOnly] public StatModifier statModifier;
        public int amount;
    }

    public enum StatModifier
    {
        strength,
        dexterity,
        intelligence,
        wisdom
    }

    void Awake()
    {
        // Initialize
        characterStat[0].statModifier = StatModifier.strength;
        characterStat[1].statModifier = StatModifier.dexterity;
        characterStat[2].statModifier = StatModifier.intelligence;
        characterStat[3].statModifier = StatModifier.wisdom;
    }

    void OnValidate()
    {
        // Do not allow designers to add new modifiers unless the programmers allow them to
        if (characterStat.Length != System.Enum.GetValues(typeof(StatModifier)).Length)
        {
            // Cache the enum length
            int StatModifierLength = System.Enum.GetValues(typeof(StatModifier)).Length;

            // Initialize a temp CharacterStat array
            CharacterStat[] characterStats = new CharacterStat[StatModifierLength];

            // Initialize all the data for statModifier
            characterStats[0].statModifier = StatModifier.strength;
            characterStats[1].statModifier = StatModifier.dexterity;
            characterStats[2].statModifier = StatModifier.intelligence;
            characterStats[3].statModifier = StatModifier.wisdom;

            // Retain the amount in the old array
            for (int i = 0; i < StatModifierLength; i++)
            {
                characterStats[i].amount = characterStat[i].amount;
            }

            // Restore the old array
            characterStat = characterStats;
        }
    }
}
