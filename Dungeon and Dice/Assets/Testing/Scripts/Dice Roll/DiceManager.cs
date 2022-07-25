using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager to hold refernce of dice Prefeb
/// </summary>
public class DiceManager : Singleton<DiceManager>
{
    [Header("Data")]
    [Tooltip("Match the dieSize with the die's object prefeb")]
    public DieMatching[] dieMatching;

    [System.Serializable]
    public struct DieMatching
    {
        public DieSize dieSize;
        public Dice diePrefeb;
    }

    public enum DieSize
    {
        D4,
        D6,
        D8,
        D10,
        D12,
        D20
    };
}
