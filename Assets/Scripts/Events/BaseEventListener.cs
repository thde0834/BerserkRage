using UnityEngine;
using UnityEngine.Events;

public interface IEventListener
{
    public void OnEventRaised();
}

public class BaseEventListener : MonoBehaviour, IEventListener
{
    [Tooltip("Event to register with.")]
    public BaseEventTrigger Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}
