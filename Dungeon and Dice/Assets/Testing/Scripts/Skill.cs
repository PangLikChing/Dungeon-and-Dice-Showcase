using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// A class to handle a skill's behaviour
/// </summary>
public class Skill : MonoBehaviour
{
    [Header("Data")]
    [Tooltip("Starting skill data for this skill")]
    [SerializeField] SkillData skillData;
    [Tooltip("Die size for this skill")]
    [SerializeField][ReadOnly] Dice.DieSize dieSize;
    [Tooltip("Number of die for damage for this skill")]
    [SerializeField][ReadOnly] int numberOfDie = 1;
    [Tooltip("Current skill level for this skill")]
    [SerializeField][ReadOnly] int currentSkillLevel = 1;

    [Header("Reference")]
    [Tooltip("Skill Name Text Component for this skill")]
    [SerializeField] TMP_Text skillNameText;
    [Tooltip("Skill Desription Text Component for this skill")]
    [SerializeField] TMP_Text skillDesriptionText;
    void Start()
    {
        try
        {
            // Initialize
            currentSkillLevel = 0;
            numberOfDie = skillData.skillLevel[currentSkillLevel].diceNumber;
            dieSize = skillData.skillLevel[currentSkillLevel].dieSize;
            skillNameText.text = skillData.skillName;
            skillDesriptionText.text = numberOfDie.ToString() + dieSize.ToString();
        }
        catch
        {
            // Throw a debug message
            Debug.Log("Skill data is missing or skill data has no skill level!");

            // Destory this game object
            Destroy(gameObject);
        }
    }

    // Method to upgrade the skill
    public void UpgradeSkill()
    {
        // Throw a debug message
        Debug.Log($"Upgrading skill: {skillNameText} to level {currentSkillLevel + 1}");

        // If the skill will not exceed maximum skill level after upgrading
        if (currentSkillLevel + 1 <= skillData.skillLevel.Length)
        {
            // Upgrade the skill
            currentSkillLevel += 1;
            numberOfDie = skillData.skillLevel[currentSkillLevel].diceNumber;
            dieSize = skillData.skillLevel[currentSkillLevel].dieSize;

            // Update the UI
            skillDesriptionText.text = numberOfDie.ToString() + dieSize.ToString();
        }
        // If the skill will exceed maximum skill level after upgrading
        else
        {
            // Throw a debug message
            Debug.Log("Cannot upgrade a skill beyond maximum skill level!");
        }
    }

    // Method to use the skill
    // TODO : Change this to accept para later (Character source, Character target, int amount)
    public void ExecuteSkill()
    {
        // Throw a debug message
        Debug.Log($"Executing skill: {skillNameText.text}");

        // TODO : Calculate the amount needed for executing here
    }
}
