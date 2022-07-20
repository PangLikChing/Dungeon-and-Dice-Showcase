using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// A class to handle dice's drag drop behaviour
/// </summary>
[RequireComponent(typeof(Dice), typeof(RectTransform))]
public class DiceDragHandler : DragHandler
{
    public override void OnBeginDrag(PointerEventData eventData)
    {
        // Execute the base DragHandler class's code
        base.OnBeginDrag(eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        // Execute the base DragHandler class's code
        base.OnDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        // Execute the base DragHandler class's code
        base.OnEndDrag(eventData);
    }
}
