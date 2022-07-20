using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object that holds the starting data of a shielding skill
/// </summary>
[CreateAssetMenu(fileName = "Shielding Skill Data", menuName = "Skill/Shielding Skill Data")]
public class ShieldingSkillData : SkillData
{
    // Method to execute the shielding skill
    public override void ExecuteSkill(Character target, Character source, int shielding)
    {
        // If the shielding skill is an AOE skill
        if (isAOE == true)
        {
            // Cache the player list in game manager
            List<Player> activePlayers = GameManager.Instance.playerList;

            // Shield all active players
            for (int i = 0; i < activePlayers.Count; i++)
            {
                source.Shield(activePlayers[i], shielding);
            }
        }
        // If the shielding skill is a single-targeted skill
        else
        {
            // Shield the target player
            source.Shield(target, shielding);
        }
    }
}
