using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterIntIntEventListener : MonoBehaviour
{
    [Tooltip("The event channel scritpable object")]
    public CharacterIntIntEventChannel channel;
    [Tooltip("Callback to respond to the unity event")]
    public UnityEvent<Character, int, int> response;

    private void OnEnable()
    {
        channel.RegisterListener(this);
    }

    private void OnDisable()
    {
        channel.UnregisterListener(this);
    }

    public void OnEventRaised(Character character ,int integer1, int integer2)
    {
        response.Invoke(character, integer1, integer2);
    }
}
