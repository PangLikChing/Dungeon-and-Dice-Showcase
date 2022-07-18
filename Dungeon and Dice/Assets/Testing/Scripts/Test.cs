using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script for testing purposes
/// </summary>
public class Test : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;

    void Start()
    {
        // Test
        enemy.ChangeShield(8);
        enemy.TakeDamage(5);
        enemy.TakeDamage(5);
        enemy.TakeDamage(5);
        enemy.TakeDamage(999);
        // Test
    }
}
