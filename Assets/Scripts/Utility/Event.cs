using UnityEngine.Events;
using UnityEngine;


public class Event<T> where T:Event<T>
{

    private static UnityAction action;
    public static void Register(UnityAction _action)
    {
        action += _action;
    }
    public static void UnRegister(UnityAction _action)
    {
        action -= _action;
    }

    public static void Trigger()
    {
        action?.Invoke();
    }
}
