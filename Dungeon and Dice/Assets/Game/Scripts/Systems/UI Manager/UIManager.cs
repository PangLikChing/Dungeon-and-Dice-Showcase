using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager to handle all comunications from game world to UI for UI display
/// </summary>
public class UIManager : Singleton<UIManager>
{
    [Header("Reference")]
    [Tooltip("Reference to the instantiated target marker")]
    RectTransform instantiatedTargetMarker = null;
    [Tooltip("Target marker prefeb that will be instantiated")]
    [SerializeField] RectTransform targetMarker;
    [Tooltip("Canvas that the gameplay related object should be in")]
    public Canvas gameplayCanvas;

    public void CreateTargetUI(Transform hitTransform)
    {
        // If there is no target marker instantiated into the game yet
        if (instantiatedTargetMarker == null)
        {
            // Instatiate a target marker gameObject in the Canvas
            instantiatedTargetMarker = Instantiate(targetMarker, gameplayCanvas.transform).GetComponent<RectTransform>();
        }

        // Scale up the targeting marker while keeping the target marker instantiated a square
        // If the local scale x of hitTransform is larger than that of y
        // Make 100% that the target marker is a square
        if (hitTransform.localScale.x >= hitTransform.localScale.y)
        {
            instantiatedTargetMarker.sizeDelta = new Vector2(targetMarker.sizeDelta.x * hitTransform.localScale.x, targetMarker.sizeDelta.x * hitTransform.localScale.x);
        }
        else
        {
            instantiatedTargetMarker.sizeDelta = new Vector2(targetMarker.sizeDelta.y * hitTransform.localScale.y, targetMarker.sizeDelta.y * hitTransform.localScale.y);
        }

        // Change the instantiated target marker's position
        instantiatedTargetMarker.position = Camera.main.WorldToScreenPoint(hitTransform.position);
    }
}
