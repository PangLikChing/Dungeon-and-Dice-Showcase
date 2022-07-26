using Project.Build.Commands;
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
    public DieMatching[] dieMatching = new DieMatching[6];

    [System.Serializable]
    public struct DieMatching
    {
        [ReadOnly] public DieSize dieSize;
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

    void Awake()
    {
        // Initialize
        dieMatching[0].dieSize = DieSize.D4;
        dieMatching[1].dieSize = DieSize.D6;
        dieMatching[2].dieSize = DieSize.D8;
        dieMatching[3].dieSize = DieSize.D10;
        dieMatching[4].dieSize = DieSize.D12;
        dieMatching[5].dieSize = DieSize.D20;
    }

    void OnValidate()
    {
        // Do not allow designers to add new die unless the programmers allow them to
        if (dieMatching.Length != System.Enum.GetValues(typeof(DieSize)).Length)
        {
            // Cache the enum length
            int DieSizeLength = System.Enum.GetValues(typeof(DieSize)).Length;

            // Initialize a temp DieMatching array
            DieMatching[] dieMatchings = new DieMatching[DieSizeLength];

            // Initialize all the data for dieSize
            dieMatchings[0].dieSize = DieSize.D4;
            dieMatchings[1].dieSize = DieSize.D6;
            dieMatchings[2].dieSize = DieSize.D8;
            dieMatchings[3].dieSize = DieSize.D10;
            dieMatchings[4].dieSize = DieSize.D12;
            dieMatchings[5].dieSize = DieSize.D20;

            // Retain the die prefeb in the old array
            for (int i = 0; i < DieSizeLength; i++)
            {
                dieMatchings[i].diePrefeb = dieMatching[i].diePrefeb;
            }

            // Restore the old array
            dieMatching = dieMatchings;
        }
    }
}
