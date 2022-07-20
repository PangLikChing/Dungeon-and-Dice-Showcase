using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager to handle all comunication from game world to UI for UI display
/// </summary>
public class UIManager : Singleton<UIManager>
{
    [Tooltip("Canvas that the gameplay related object should be in")]
    public Canvas gameplayCanvas;
}
