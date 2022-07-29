using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Skill))]
public class SkillButton : MonoBehaviour
{
    [Tooltip("Raise when there is no current target")]
    public UnityEvent<Transform> TryChangeTarget;

    public void ExecuteSkill()
    {
        // Get a reference to the parent's skill component
        Skill skill = transform.GetComponent<Skill>();

        try
        {
            // If the current encounter is a battle
            if (GameManager.Instance.currentEncounter.GetType() == typeof(Battle))
            {
                // If the skill is a damaging skill
                if (skill.skillData.GetType() == typeof(DamageSkillData))
                {
                    // If there is no enemy target yet
                    if (GameManager.Instance.currentEnemyTarget == null)
                    {
                        try
                        {
                            // Try to set the target at the first enemy in the enemy list in the game manager
                            TryChangeTarget.Invoke(GameManager.Instance.enemyList[0].transform);
                        }
                        catch
                        {
                            // Throw a debug message
                            Debug.Log("There is no enemy left!");
                        }
                    }
                }
                // If the skill is a healing or shielding skill
                else if (skill.skillData.GetType() == typeof(HealingSkillData) || skill.skillData.GetType() == typeof(ShieldingSkillData))
                {
                    Debug.Log("Support Skill");
                    // Cast the skill as a support skill
                    SupportSkillData supportSkillData = (SupportSkillData)skill.skillData;

                    // If the skill can only target the caster
                    // If the healing skill can only target the caster
                    if (supportSkillData.targetSelfOnly == true)
                    {
                        Debug.Log("Success");

                        // Try to set the target at the caster in the game manager
                        TryChangeTarget.Invoke(GameManager.Instance.currentPlayer.transform);
                    }

                    // If there is no player target yet
                    if (GameManager.Instance.currentPlayerTarget == null)
                    {
                        try
                        {
                            // Try to set the target at the first player in the player list in the game manager
                            TryChangeTarget.Invoke(GameManager.Instance.playerList[0].transform);
                        }
                        catch
                        {
                            // Throw a debug message
                            Debug.Log("There is no player left!");
                        }
                    }
                }

                // Roll the dice and execute the skill
                StartCoroutine(RollDiceAndExecuteSkill(skill));
            }
        }
        catch
        {
            // Throw a debug message
            Debug.Log("Unknown encounter type!");
        }
    }
    IEnumerator RollDiceAndExecuteSkill(Skill skill)
    {
        // Intialize a temp transform prefeb to store the die object prefeb
        Dice die = null;

        // Determine the die object prefeb needed
        for (int i = 0; i < DiceManager.Instance.dieMatching.Length; i++)
        {
            // If the die size in the skill is the same as the one in dice manager
            if (skill.dieSize == DiceManager.Instance.dieMatching[i].dieSize)
            {
                die = DiceManager.Instance.dieMatching[i].diePrefeb;
            }
        }

        // Instantiate a die object for every die needed and roll them
        for (int i = 0; i < skill.numberOfDie; i++)
        {
            // Instantiate the die
            Dice dice = Instantiate(die, DiceRollTray.Instance.transform);

            // Roll the die
            dice.RollDie();
        }

        // Wait for the die to finish the roll
        yield return new WaitForSeconds(die.rollingTime);

        // Initialzie a temp int to store the roll result
        int rollResults = 0;

        // Calculate the total amount of roll results
        for (int i = 0; i < DiceRollTray.Instance.transform.childCount; i++)
        {
            rollResults += DiceRollTray.Instance.transform.GetChild(i).GetComponent<Dice>().rollResult;
        }

        // Execute the skill
        // TODO : Calculate damage here
        // If the skill is a damaging skill
        if (skill.skillData.GetType() == typeof(DamageSkillData))
        {
            // Execute the skill on the targeted enemy, no matter it is an AOE or not
            skill.ExecuteSkill(GameManager.Instance.currentPlayer, GameManager.Instance.currentEnemyTarget, rollResults);
        }
        // If the skill is a healing or shielding skill
        else if (skill.skillData.GetType() == typeof(HealingSkillData) || skill.skillData.GetType() == typeof(ShieldingSkillData))
        {
            // Execute the skill on the targeted player, no matter it is an AOE or not
            skill.ExecuteSkill(GameManager.Instance.currentPlayer, GameManager.Instance.currentPlayerTarget, rollResults);
        }
    }
}
