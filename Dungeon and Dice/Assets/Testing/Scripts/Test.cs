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
        player.ChangeShield(8);
        enemy.Attack(player, 5);
        enemy.Attack(player, 5);
        enemy.Attack(player, 10);
        enemy.Attack(player, 999);
        // Test
    }
}
