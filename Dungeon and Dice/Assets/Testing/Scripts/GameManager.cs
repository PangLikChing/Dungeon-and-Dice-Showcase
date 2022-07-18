using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game Manager should be the one who communicate between game world and systems
/// </summary>
public class GameManager : Singleton<GameManager>
{
    [Tooltip("List of active players")]
    [SerializeField] List<Player> playerList;
    [Tooltip("List of active enemies")]
    [SerializeField] List<Enemy> enemyList;

    // Method to add the player to the player list
    public void AddPlayer(Player player)
    {
        // Throw a debug message
        Debug.Log($"Adding {player.name} into the player list");

        // Add the player to the player list
        playerList.Add(player);
    }

    // Method to add the enemy to the enemy list
    public void AddEnemy(Enemy enemy)
    {
        // Throw a debug message
        Debug.Log($"Adding {enemy.name} into the enemy list");

        // Add the enemy to the enemy list
        enemyList.Add(enemy);
    }

    // Method to remove the player to the player list
    public void RemovePlayer(Player player)
    {
        // Throw a debug message
        Debug.Log($"Removing {player.name} from the player list");

        // Remove the player to the player list
        playerList.Remove(player);
    }

    // Method to remove the enemy to the enemy list
    public void RemoveEnemy(Enemy enemy)
    {
        // Throw a debug message
        Debug.Log($"Removing {enemy.name} from the enemy list");

        // Remove the enemy to the enemy list
        enemyList.Remove(enemy);
    }

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
