using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterIntIntEventChannel", menuName = "Event/Character Int Int Event Channel")]
public class CharacterIntIntEventChannel : ScriptableObject
{
    private List<CharacterIntIntEventListener> listeners = new List<CharacterIntIntEventListener>();

    public void Raise(Character character, int integer1, int integer2)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(character, integer1, integer2);
        }
    }

    public void RegisterListener(CharacterIntIntEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(CharacterIntIntEventListener listener)
    {
        listeners.Remove(listener);
    }
}
