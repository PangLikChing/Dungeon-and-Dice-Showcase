using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Base class to handle object's drag drop behaviour
/// </summary>
public class DropHandler : MonoBehaviour, IDropHandler
{
    [Header("Drop Handler")]
    [Tooltip("The object transform that this dropping field is currently holding")]
    /*[HideInInspector] */public Transform heldObject = null;

    public virtual void OnDrop(PointerEventData eventData)
    {
        // Throw a debug message
        Debug.Log($"{eventData.pointerDrag.name} is being dropped on {gameObject.name}");

        // If this dropping field is currently not holding any object
        if (heldObject == null)
        {
            // Get a reference to the dropped transform
            heldObject = eventData.pointerDrag.transform;

            // Set the parent of the dropped object to this dropping field
            heldObject.SetParent(transform);

            // Snap the object to the centre of the gameObject being dropped on
            heldObject.localPosition = Vector2.zero;
        }
    }
}
