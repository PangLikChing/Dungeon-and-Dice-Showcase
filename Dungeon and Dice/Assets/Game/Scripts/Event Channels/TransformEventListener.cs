using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransformEventListener : MonoBehaviour
{
    [Tooltip("The event channel scritpable object")]
    public TransformEventChannel channel;
    [Tooltip("Callback to respond to the unity event")]
    public UnityEvent<Transform> response;

    private void OnEnable()
    {
        channel.RegisterListener(this);
    }

    private void OnDisable()
    {
        channel.UnregisterListener(this);
    }

    public void OnEventRaised(Transform transform)
    {
        response.Invoke(transform);
    }
}
