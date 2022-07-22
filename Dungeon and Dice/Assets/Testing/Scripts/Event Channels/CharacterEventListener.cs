using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterEventListener : MonoBehaviour
{
    [Tooltip("The event channel scritpable object")]
    public CharacterEventChannel channel;
    [Tooltip("Callback to respond to the unity event")]
    public UnityEvent<Character> response;

    private void OnEnable()
    {
        channel.RegisterListener(this);
    }

    private void OnDisable()
    {
        channel.UnregisterListener(this);
    }

    public void OnEventRaised(Character character)
    {
        response.Invoke(character);
    }
}
