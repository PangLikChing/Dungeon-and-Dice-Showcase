using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script responsible for displaying the volume amount
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class VolumeText : MonoBehaviour
{
    [Header("Reference")]
    [Tooltip("Scrollbar that this text is responsible to respresent")]
    [SerializeField] Scrollbar scrollbar;
    [Tooltip("TMP_Text component of this text")]
    TMP_Text myText;

    void Start()
    {
        // Initialize
        myText = GetComponent<TMP_Text>();

        // Update text according to current value
        UpdateValue();
    }

    // Method to update value according to the scrollbar that this text is responsible to
    public void UpdateValue()
    {
        try
        {
            // Update text, only showing the whole number
            myText.text = (scrollbar.value * 10).ToString("F0");
        }
        catch
        {
            // Throw a debug message
            Debug.Log("Scrollbar is missing!");
        }
    }
}
