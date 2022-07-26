using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Dice Roll Tray Identifier, should only have 1 at the same time
/// </summary>
public class DiceRollTray : Singleton<DiceRollTray>
{
    // Method to clear all children gameObjects (dice)
    public void RemoveDice()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(0));
        }
    }
}
