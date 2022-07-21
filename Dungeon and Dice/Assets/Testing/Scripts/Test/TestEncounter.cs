using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for testing encounters
/// </summary>
public class TestEncounter : MonoBehaviour
{
    [SerializeField] Player player;

    [SerializeField] Encounter encounter;

    [SerializeField] Battle battle;

    [SerializeField] float encounterTime;

    void Start()
    {
        GameManager.Instance.StartEncounter(encounter);
    }
}
