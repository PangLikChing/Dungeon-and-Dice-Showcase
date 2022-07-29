using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object that stores the data of a character class / job
/// </summary>
[CreateAssetMenu(fileName = "Class", menuName = "Class/Class")]
public class Class : ScriptableObject
{
    public string className;

    public SkillData[] skillsData;
}
