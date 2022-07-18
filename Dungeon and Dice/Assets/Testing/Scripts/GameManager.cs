using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Game Manager should be the one who communicate between game world and systems
/// </summary>
public class GameManager : Singleton<GameManager>
{
    public void UpdateCharacterAttack(Character character, int attack)
    {
        // Throw a debug message
        Debug.Log($"{gameObject.name} is updating {character.name}'s attack");
    }

    public void UpdateCharacterCurrentHealth(Character character, int currentHealth)
    {
        // Throw a debug message
        Debug.Log($"{gameObject.name} is updating {character.name}'s current health");
    }

    public void UpdateCharacterMaximumHealth(Character character, int maximumHealth)
    {
        // Throw a debug message
        Debug.Log($"{gameObject.name} is updating {character.name}'s maximum health");
    }

    public void UpdateCharacterShield(Character character, int shield)
    {
        // Throw a debug message
        Debug.Log($"{gameObject.name} is updating {character.name}'s shield");
    }
}
