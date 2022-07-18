using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An abstract class for all characters in the game
/// </summary>
public abstract class Character : MonoBehaviour
{
    [Header("Stats")]
    [Tooltip("Attack of the character")]
    [SerializeField][ReadOnly] protected int attack = 0;
    [Tooltip("Maximum health of the character")]
    [SerializeField] [ReadOnly] protected int maximumHealth = 0;
    [Tooltip("Current health that the character currently has")]
    [SerializeField][ReadOnly] protected int currentHealth = 0;
    [Tooltip("Shield that the character currently has")]
    [SerializeField][ReadOnly] protected int shield = 0;

    // Method to let the character take damage
    public virtual void TakeDamage(int damage)
    {
        // If the character is dead already
        if (currentHealth <= 0)
        {
            // Ignore the take damage request
            return;
        }

        // Throw a debug message
        Debug.Log($"{gameObject.name} is taking {damage} damage!");

        // Reduce from shield first
        if (shield > 0)
        {
            // If the shield itself can take all the damage
            if (shield >= damage)
            {
                // Reduce it from the shield
                ChangeShield(-damage);
            }
            // If the shield is not enough to take all the damage
            else
            {
                // Initialize a temp int to know how much health is needed to be deducted
                int healthDamage = damage - shield;

                // Deplete all the shields
                shield = 0;

                // Reduce the current health by health damage
                ChangeCurrentHealth(-healthDamage);
            }
        }
        // If there are no shields
        else
        {
            // Reduce the current health by health damage
            ChangeCurrentHealth(-damage);
        }
    }

    // Method to change current health (can be increase or decrease)
    public virtual void ChangeCurrentHealth(int amount)
    {
        // Throw a debug message
        Debug.Log($"{gameObject.name} is changing {amount} amount of current health!");

        // If the current health will exceed the maximum health after the amount is added
        if (currentHealth + amount > maximumHealth)
        {
            // Make the current health the same as max health
            currentHealth = maximumHealth;
        }
        // If it doesn't exceed the maximum health
        else
        {
            // Change that amount of health
            currentHealth += amount;
        }

        // Throw a debug message
        Debug.Log($"{gameObject.name} has {currentHealth} health with {shield} shield remaining!");
    }

    // Method to change maximum health (can be increase or decrease)
    public virtual void ChangeMaximumHealth(int amount)
    {
        // Throw a debug message
        Debug.Log($"{gameObject.name} is changing {amount} amount of maximum health!");

        // Change the maximum health
        maximumHealth += amount;

        // If the amount is positive
        if (amount > 0)
        {
            // Heal the character by that amount
            ChangeCurrentHealth(amount);
        }

        // If the current health exceed the maximum health after changing the maximum health
        if (currentHealth > maximumHealth)
        {
            // Make the current health the same as the maximum health
            currentHealth = maximumHealth;
        }

        // Throw a debug message
        Debug.Log($"{gameObject.name} has {currentHealth} health with {maximumHealth} amount of maximum health!");
    }

    // Method to change shield (can be increase or decrease)
    public virtual void ChangeShield(int amount)
    {
        // Throw a debug message
        Debug.Log($"{gameObject.name} is changing {amount} amount of shield!");

        // Change the shield by the amount
        shield += amount;

        // Throw a debug message
        Debug.Log($"{gameObject.name} has {currentHealth} health with {shield} shield remaining!");
    }

    // Method called when the character dies
    protected abstract void Death();
}
