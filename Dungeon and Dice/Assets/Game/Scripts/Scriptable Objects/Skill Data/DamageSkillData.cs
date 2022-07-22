using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object that holds the starting data of a damaging skill
/// </summary>
[CreateAssetMenu(fileName = "Damage Skill Data", menuName = "Skill/Damage Skill Data")]
public class DamageSkillData : SkillData
{
    // Method to execute the damaging skill
    public override void ExecuteSkill(Character source, Character target, int damage)
    {
        // If the damaging skill is an AOE skill
        if (isAOE == true)
        {
            // Initialize a temp enemy list
            List<Enemy> activeEnemies = new List<Enemy>();

            // Create a copy of the enemy list in game manager
            for (int i = 0; i < GameManager.Instance.enemyList.Count; i++)
            {
                activeEnemies.Add(GameManager.Instance.enemyList[i]);
            }

            // Deal damage to all active enemies
            for (int i = 0; i < activeEnemies.Count; i++)
            {
                source.Attack(activeEnemies[i], damage);
            }
        }
        // If the damaging skill is a single-targeted skill
        else
        {
            // Deal damage to the target enemy
            source.Attack(target, damage);
        }
    }
}
