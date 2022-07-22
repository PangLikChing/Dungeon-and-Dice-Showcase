using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manager to handle all comunications between targeting system and Game Manager
/// </summary>
public class TargetingManager : Singleton<TargetingManager>
{
    [Tooltip("Raise when player targets a character")]
    public UnityEvent<Character> ChangeTarget;
}
