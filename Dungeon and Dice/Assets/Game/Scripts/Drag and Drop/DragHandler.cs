using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Base class to handle object's drag drop behaviour
/// </summary>
[RequireComponent(typeof(CanvasGroup), typeof(RectTransform))]
public class DragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [Header("Drop Handler")]
    [Tooltip("Canvas that this object is belonging to")]
    Canvas canvas;
    [Tooltip("CanvasGroup of this object")]
    CanvasGroup canvasGroup;
    [Tooltip("RectTransform of this object")]
    RectTransform rectTransform;
    [Tooltip("The original parent transform of this object before it got dragged")]
    Transform originalParent = null;
    [Tooltip("The original position of this object before it got dragged")]
    Vector2 originalPosition = Vector2.zero;

    void Start()
    {
        // Initialize
        canvas = UIManager.Instance.gameplayCanvas;
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        // Throw a debug message
        Debug.Log($"{eventData.pointerDrag.name} started being dragged");

        // Remember the parent that this object is originally under
        originalParent = transform.parent;

        // Remember the position of this object originally
        originalPosition = transform.position;

        // If this object is currently a child of a droppable field
        if (transform.parent.GetComponent<DropHandler>() != null)
        {
            // Tell the droppable field that I am no longer held by it
            transform.parent.GetComponent<DropHandler>().heldObject = null;
        }

        // Set the object the last element of the canvas for good visual
        // Only works if the object's original parent is not the canvas itself
        transform.SetParent(canvas.transform);

        // Allow this object being dropped
        canvasGroup.blocksRaycasts = false;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        // If I am dragging with my left mouse button down
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Move the dragged object with mouse
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        // Throw a debug message
        Debug.Log($"{eventData.pointerDrag.name} stopped being dragged");

        // Allow this object being dragged again
        canvasGroup.blocksRaycasts = true;

        // If I am not a child of a dropping field at the end of drag
        if (transform.parent.GetComponent<DropHandler>() == null)
        {
            // Return to the original parent before drag
            transform.SetParent(originalParent);

            // If the original parent is a dropping field
            if (originalParent.GetComponent<DropHandler>() != null)
            {
                // If the dropping field can only hold an object at a time
                if (originalParent.GetComponent<DropHandler>().multipleHeldObjects == false)
                {
                    // Tell the original parent that this object returned
                    originalParent.GetComponent<DropHandler>().heldObject = transform;
                }
            }

            // Return to the original position before drag
            transform.position = originalPosition;
        }

        // Reset originalParent to prevent bugs
        originalParent = null;

        // Reset originalPosition to prevent bugs
        originalPosition = Vector2.zero;
    }
}
