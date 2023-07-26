using UnityEngine;

public abstract class Analytics : MonoBehaviour
{
    public abstract void SendEvent(string eventName);
}