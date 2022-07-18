using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatEventListener : MonoBehaviour
{
    [Tooltip("The event channel scritpable object")]
    public FloatEventChannel channel;
    [Tooltip("Callback to respond to the unity event")]
    public UnityEvent<float> response;

    private void OnEnable()
    {
        channel.RegisterListener(this);
    }

    private void OnDisable()
    {
        channel.UnregisterListener(this);
    }

    public void OnEventRaised(int integer)
    {
        response.Invoke(integer);
    }
}
