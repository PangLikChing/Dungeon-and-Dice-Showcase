using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// A class to handle skill dropboxes' drop behaviour
/// </summary>
public class SkillDropboxDropHandler : DropHandler
{
    // More events here to remove all usage of Game Manager.Instance

    [Tooltip("Raise when there is no current target")]
    public UnityEvent<Transform> TryChangeTarget;

    public override void OnDrop(PointerEventData eventData)
    {
        // Execute the base DropHandler class's code
        base.OnDrop(eventData);

        // If the dropped object is a dice
        if (eventData.pointerDrag.GetComponent<Dice>() != null)
        {
            try
            {
                // Get a reference to the parent's skill component
                Skill skill = transform.parent.GetComponent<Skill>();

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
                    // If the current encounter is a rest event
                    else if (GameManager.Instance.currentEncounter.GetType() == typeof(Resting))
                    {
                        // If the die size of the dropped object and the skill matches
                        if (eventData.pointerDrag.GetComponent<Dice>().dieSize == skill.dieSize)
                        {
                            // Upgrade the skill
                            skill.UpgradeSkill();
                        }
                    }
                    // Else
                    else
                    {
                        // Throw a debug message
                        Debug.Log("Unknown encounter type!");
                    }
                }
                catch
                {
                    // Throw a debug message
                    Debug.Log("There is no encounter!");
                }
            }
            catch
            {
                // Throw a debug message
                Debug.Log("My parent is not a skill");
            }
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
