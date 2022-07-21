using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// A class to handle skill dropboxes' drop behaviour
/// </summary>
public class SkillDropboxDropHandler : DropHandler
{
    public override void OnDrop(PointerEventData eventData)
    {
        // Execute the base DropHandler class's code
        base.OnDrop(eventData);

        try
        {
            // Get a reference to the parent's skill component
            Skill skill = transform.parent.GetComponent<Skill>();

            // If the current encounter is a battle
            if (GameManager.Instance.currentEncounter.GetType() == typeof(Battle))
            {
                // Execute the skill
                skill.ExecuteSkill();
            }
            // If the current encounter is a rest event
            else if (GameManager.Instance.currentEncounter.GetType() == typeof(Resting))
            {
                // Upgrade the skill
                skill.UpgradeSkill();
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
            Debug.Log("My parent is not a skill");
        }
    }
}
