using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TransformEventChannel", menuName = "Event/Transform Event Channel")]
public class TransformEventChannel : ScriptableObject
{
    private List<TransformEventListener> listeners = new List<TransformEventListener>();

    public void Raise(Transform transform)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(transform);
        }
    }

    public void RegisterListener(TransformEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(TransformEventListener listener)
    {
        listeners.Remove(listener);
    }
}
