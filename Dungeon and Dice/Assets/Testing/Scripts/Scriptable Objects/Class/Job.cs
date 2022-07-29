using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object that stores the data of a character's job / class
/// </summary>
[CreateAssetMenu(fileName = "Job", menuName = "Job/Job")]
public class Job : ScriptableObject
{
    public string jobName;

    public SkillData[] skillsData;
}
