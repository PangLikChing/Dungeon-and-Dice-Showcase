using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game Manager should be the one who communicate between game world and systems
/// </summary>
public class GameManager : Singleton<GameManager>
{
    [Header("References")]
    [Tooltip("An empty game object for the enemies instantiated to help organise the hierarchy")]
    [SerializeField] Transform enemiesParent;
    [Header("Data")]
    [Tooltip("List of active players, there should only be 1 player most of the time")]
    [ReadOnly] public List<Player> playerList;
    [Tooltip("List of active enemies")]
    [ReadOnly] public List<Enemy> enemyList;
    [Tooltip("Last player that the user targets")]
    [ReadOnly] public Character currentPlayerTarget = null;
    [Tooltip("Last enemy that the user targets")]
    [ReadOnly] public Character currentEnemyTarget = null;
    [Tooltip("The current encounter")]
    [ReadOnly] public Encounter currentEncounter;
    [Tooltip("Current encounter's win condition")]
    [ReadOnly] public List<Enemy> currentWinCondition;

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

        // Destory the enemy game object
        Destroy(enemy.gameObject);

        // If the current encounter is a battle (which it should be)
        if (currentEncounter.GetType() == typeof(Battle))
        {
            // Cast the current encounter as a battle
            Battle battle = (Battle)currentEncounter;

            // If the win condition is met
            if (CheckFulfillWinCondition(battle) == true)
            {
                FinishEncounter();
            }
        }
    }

    public void ChangeTarget(Character character)
    {
        // If the character is a player
        if (character.GetType() == typeof(Player))
        {
            currentPlayerTarget = character;
        }
        else if (character.GetType() == typeof(Enemy))
        {
            currentEnemyTarget = character;
        }
    }

    // Method to update a character's attack
    public void UpdateCharacterAttack(Character character, int attack)
    {
        // Throw a debug message
        Debug.Log($"{gameObject.name} is updating {character.name}'s attack");
    }

    // Method to update a character's current health
    public void UpdateCharacterCurrentHealth(Character character, int currentHealth)
    {
        // Throw a debug message
        Debug.Log($"{gameObject.name} is updating {character.name}'s current health");
    }

    // Method to update a character's maximum health
    public void UpdateCharacterMaximumHealth(Character character, int maximumHealth)
    {
        // Throw a debug message
        Debug.Log($"{gameObject.name} is updating {character.name}'s maximum health");
    }

    // Method to update a character's shield
    public void UpdateCharacterShield(Character character, int shield)
    {
        // Throw a debug message
        Debug.Log($"{gameObject.name} is updating {character.name}'s shield");
    }

    // Method to start an encounter
    public void StartEncounter(Encounter encounter)
    {
        // Throw a debug message
        Debug.Log($"Starting encounter: {encounter.name}");

        // Set the current encounter to the encounter
        currentEncounter = encounter;

        // If the encounter is a battle
        if (encounter.GetType() == typeof(Battle))
        {
            // Cast the encounter as Battle
            Battle battle = (Battle)encounter;

            // Instantiate and store the enemies into the game
            for (int i = 0; i < battle.enemies.Length; i++)
            {
                Instantiate(battle.enemies[i], enemiesParent);
            }

            // Record the win condition of the encounter
            for (int i = 0; i < battle.winCondition.Length; i++)
            {
                currentWinCondition.Add(enemyList[battle.winCondition[i]]);
            }
        }
    }

    // Method to finish an encounter
    public void FinishEncounter()
    {
        // Throw a debug message
        Debug.Log($"Finishing encounter: {currentEncounter.name}");

        // If the encounter is a battle
        if (currentEncounter.GetType() == typeof(Battle))
        {
            // Initialize a temp int to store the number of remaining enemies in the enemy list
            int remainingEnemiesNumber = enemyList.Count;

            // Remove all remaining enemies out of the game
            for (int i = 0; i < remainingEnemiesNumber; i++)
            {
                // Get a reference of that enemy
                Enemy enemy = enemyList[0];

                // Throw a debug message
                Debug.Log($"Removing {enemy.name} from the enemy list");

                // Remove the enemy to the enemy list
                enemyList.Remove(enemy);

                // Destory the enemy game object
                Destroy(enemy.gameObject);
            }
        }

        // Remove current encounter
        currentEncounter = null;
    }

    // Return "true" if the win condition is met
    private bool CheckFulfillWinCondition(Battle battle)
    {
        // Compare every enemy in the enemy list and check if the win condition enemy is in there
        for (int i = 0; i < battle.winCondition.Length; i++)
        {
            for (int j = 0; j < enemyList.Count; j++)
            {
                // If the win condition enemy is still in the enemy list
                if (currentWinCondition[i] == enemyList[j])
                {
                    // Throw a debug message
                    Debug.Log("Win condition is not met");

                    // Return false
                    return false;
                }
            }
        }
        // Throw a debug message
        Debug.Log("Win condition is met");

        // If the win condition enemies are all absent in the enemy list, return true
        return true;
    }
}
