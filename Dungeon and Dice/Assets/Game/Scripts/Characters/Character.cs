using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An abstract class for all characters in the game
/// </summary>
public abstract class Character : MonoBehaviour
{
    [Header("Stats")]
    [Tooltip("Current attack of the character")]
    [SerializeField][ReadOnly] protected int attack = 0;
    [Tooltip("Current maximum health of the character")]
    [SerializeField] [ReadOnly] protected int maximumHealth = 0;
    [Tooltip("Current health that the character currently has")]
    [SerializeField][ReadOnly] protected int currentHealth = 0;
    [Tooltip("Current shield that the character currently has")]
    [SerializeField][ReadOnly] protected int shield = 0;
    [Tooltip("Raise this when a character's attack needs to be updated")]
    public UnityEvent<Character, int> UpdateCharacterAttack;
    [Tooltip("Raise this when a character's current health needs to be updated")]
    public UnityEvent<Character, int> UpdateCharacterCurrentHealth;
    [Tooltip("Raise this when a character's maximum health needs to be updated")]
    public UnityEvent<Character, int> UpdateCharacterMaximumHealth;
    [Tooltip("Raise this when a character's shield needs to be updated")]
    public UnityEvent<Character, int> UpdateCharacterShield;

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
                ChangeShield(-shield);

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

    // Method to change current attack (can be increase or decrease)
    public virtual void ChangeCurrentAttack(int amount)
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

        // Tell the others that my current health changed
        UpdateCharacterCurrentHealth.Invoke(this, currentHealth);

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

        // Tell the others that my current health changed
        UpdateCharacterCurrentHealth.Invoke(this, currentHealth);

        // Tell the others that my maximum health changed
        UpdateCharacterMaximumHealth.Invoke(this, maximumHealth);

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

        // Tell the others that my shield changed
        UpdateCharacterShield.Invoke(this, shield);

        // Throw a debug message
        Debug.Log($"{gameObject.name} has {currentHealth} health with {shield} shield remaining!");
    }

    // Method called when the character dies
    protected abstract void Death();
}
