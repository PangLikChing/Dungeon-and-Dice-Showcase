using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The base clase for all players in the game
/// </summary>
public class Player : Character
{
    [Header("Player")]
    [Tooltip("Stats scriptable object to determine the player's starting stats")]
    [SerializeField] Stats playerStats;

    void Awake()
    {
        // Initialize
        attack = playerStats.attack;
        maximumHealth = playerStats.maximumHealth;
        currentHealth = maximumHealth;
        shield = 0;
    }

    public override void TakeDamage(int damage)
    {
        // If the player is dead already
        if (currentHealth <= 0)
        {
            // Ignore the take damage request
            return;
        }

        // Go though the base code from character
        base.TakeDamage(damage);

        // See if the player is dead
        if (currentHealth <= 0)
        {
            // Die
            Death();
        }
    }

    // Method called when the player dies
    protected override void Death()
    {
        // Throw a debug message
        Debug.Log("Player is dead!");
    }
}
