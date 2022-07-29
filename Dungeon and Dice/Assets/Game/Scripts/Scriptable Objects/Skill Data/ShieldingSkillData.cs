using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object that holds the starting data of a shielding skill
/// </summary>
[CreateAssetMenu(fileName = "Shielding Skill Data", menuName = "Skill/Shielding Skill Data")]
public class ShieldingSkillData : SupportSkillData
{
    // Method to execute the shielding skill
    public override void ExecuteSkill(Character source, Character target, int shielding)
    {
        // If the shielding skill is a single-targeted skill
        if (isAOE == false)
        {
            // Shield the target player
            source.Shield(target, shielding);
        }
        // If the shielding skill is an AOE skill
        else
        {
            // Initialize a temp player list
            List<Player> activePlayers = new List<Player>();

            // Create a copy of the player list in game manager
            for (int i = 0; i < GameManager.Instance.playerList.Count; i++)
            {
                activePlayers.Add(GameManager.Instance.playerList[i]);
            }

            // Shield all active players
            for (int i = 0; i < activePlayers.Count; i++)
            {
                source.Shield(activePlayers[i], shielding);
            }
        }
    }
}
