using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The base clase for all enemies in the game
/// </summary>
public class Enemy : Character
{
    [Header("Enemy")]
    [Tooltip("Stats scriptable object to determine the enemy's starting stats")]
    [SerializeField] Stats enemyStats;

    void Awake()
    {
        // Initialize
        attack = enemyStats.attack;
        maximumHealth = enemyStats.maximumHealth;
        currentHealth = maximumHealth;
        shield = 0;

        // Add this enemy into Game Manager's enemyList
        GameManager.Instance.AddEnemy(this);
    }

    public override void TakeDamage(int damage, Character source)
    {
        // If the enemy is dead already
        if (currentHealth <= 0)
        {
            // Throw a debug message
            Debug.Log($"{gameObject.name} is dead already!");

            // Ignore the take damage request
            return;
        }

        // Go though the base code from character
        base.TakeDamage(damage, source);

        // See if the enemy is dead
        if (currentHealth <= 0)
        {
            // Die
            Death();
        }
    }

    // Method called when the enemy dies
    protected override void Death()
    {
        // Throw a debug message
        Debug.Log("Enemy is dead!");

        // Remove this enemy from the enemy list in the Game Manager
        GameManager.Instance.RemoveEnemy(this);
    }
}
