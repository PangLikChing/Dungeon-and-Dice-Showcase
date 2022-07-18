using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [Header("Enemy")]
    [SerializeField] Stats enemyStats;

    void Awake()
    {
        // Initialize
        attack = enemyStats.attack;
        maximumHealth = enemyStats.maximumHealth;
        currentHealth = maximumHealth;
        shield = 0;
    }

    public override void TakeDamage(int damage)
    {
        // If the enemy is dead already
        if (currentHealth <= 0)
        {
            // Ignore the take damage request
            return;
        }

        // Go though the base code from character
        base.TakeDamage(damage);

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
    }
}
