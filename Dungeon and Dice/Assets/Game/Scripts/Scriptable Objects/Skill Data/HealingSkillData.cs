using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object that holds the starting data of a healing skill
/// </summary>
[CreateAssetMenu(fileName = "Healing Skill Data", menuName = "Skill/Healing Skill Data")]
public class HealingSkillData : SupportSkillData
{
    // Method to execute the healing skill
    public override void ExecuteSkill(Character source, Character target, int healing)
    {
        // If the healing skill is an AOE skill
        if (isAOE == true)
        {
            // Initialize a temp enemy list
            List<Player> activePlayers = new List<Player>();

            // Create a copy of the player list in game manager
            for (int i = 0; i < GameManager.Instance.playerList.Count; i++)
            {
                activePlayers.Add(GameManager.Instance.playerList[i]);
            }

            // Heal all active players
            for (int i = 0; i < activePlayers.Count; i++)
            {
                source.Heal(activePlayers[i], healing);
            }
        }
        // If the healing skill is a single-targeted skill
        else
        {
            // Heal the target player
            source.Heal(target, healing);
        }
    }
}
