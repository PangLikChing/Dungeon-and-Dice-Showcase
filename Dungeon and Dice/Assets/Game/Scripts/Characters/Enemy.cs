using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The base clase for all enemies in the game
/// </summary>
public class Enemy : Character
{
    [Header("Enemy")]
    [Tooltip("Current attack of the enemy")]
    [SerializeField] int attack = 0;
    [Tooltip("Stats scriptable object to determine the enemy's starting stats")]
    [SerializeField] EnemyStats enemyStats;

    [Tooltip("Raise this when a character's attack needs to be updated")]
    public UnityEvent<Character, int> UpdateCharacterAttack;

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

    public override void TakeDamage(Character source, int damage)
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
        base.TakeDamage(source, damage);

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

    // Method to change current attack (can be increase or decrease)
    public void ChangeCurrentAttack(int amount)
    {
        // Throw a debug message
        Debug.Log($"{gameObject.name} is changing {amount} amount of attack!");

        // Change the attack by the amount
        attack += amount;

        // Tell the others that my attack changed
        UpdateCharacterAttack.Invoke(this, attack);

        // Throw a debug message
        Debug.Log($"{gameObject.name} has {attack} attack now!");
    }
}
