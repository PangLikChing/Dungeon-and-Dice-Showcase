using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterEventChannel", menuName = "Event/Character Event Channel")]
public class CharacterEventChannel : ScriptableObject
{
    private List<CharacterEventListener> listeners = new List<CharacterEventListener>();

    public void Raise(Character chracter)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(chracter);
        }
    }

    public void RegisterListener(CharacterEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(CharacterEventListener listener)
    {
        listeners.Remove(listener);
    }
}
