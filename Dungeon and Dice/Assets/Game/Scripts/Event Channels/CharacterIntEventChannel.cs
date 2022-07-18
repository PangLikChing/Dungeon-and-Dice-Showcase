using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterIntEventChannel", menuName = "Event/Character Int Event Channel")]
public class CharacterIntEventChannel : ScriptableObject
{
    private List<CharacterIntEventListener> listeners = new List<CharacterIntEventListener>();

    public void Raise(Character chracter, int integer)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(chracter, integer);
        }
    }

    public void RegisterListener(CharacterIntEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(CharacterIntEventListener listener)
    {
        listeners.Remove(listener);
    }
}
