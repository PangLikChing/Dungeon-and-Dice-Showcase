using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatEventChannel", menuName = "Event/Float Event Channel")]
public class FloatEventChannel : ScriptableObject
{
    private List<FloatEventListener> listeners = new List<FloatEventListener>();

    public void Raise(int integer)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(integer);
        }
    }

    public void RegisterListener(FloatEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(FloatEventListener listener)
    {
        listeners.Remove(listener);
    }
}
