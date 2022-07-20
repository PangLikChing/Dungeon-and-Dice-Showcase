using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object that holds the starting data of a healing skill
/// </summary>
[CreateAssetMenu(fileName = "Healing Skill Data", menuName = "Skill/Healing Skill Data")]
public class HealingSkillData : SkillData
{
    // Method to execute the healing skill
    public override void ExecuteSkill(Character target, Character source, int healing)
    {
        // If the healing skill is an AOE skill
        if (isAOE == true)
        {
            // Cache the player list in game manager
            List<Player> activePlayers = GameManager.Instance.playerList;

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
