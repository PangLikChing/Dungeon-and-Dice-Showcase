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

    Skill skill;

    void Start()
    {
        try
        {
            // Initialize
            skill = transform.parent.GetComponent<Skill>();
        }
        catch
        {
            // Throw a debug message
            Debug.Log("My parent is not a skill");
        }
    }

    public override void OnDrop(PointerEventData eventData)
    {
        // Execute the base DropHandler class's code
        base.OnDrop(eventData);

        // If the dropped object is a dice
        if (eventData.pointerDrag.GetComponent<Dice>() != null)
        {
            try
            {
                // If the current encounter is a rest event
                if (GameManager.Instance.currentEncounter.GetType() == typeof(Resting))
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
    }
}
