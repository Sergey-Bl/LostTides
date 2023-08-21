using System.Collections.Generic;
using Firebase.Analytics;
using UnityEngine;

public class FireBaseAnalytics : AbstractMetrics
{
    public override void Send(string eventName, IReadOnlyDictionary<string, string> options)
    {
        List<Parameter> parameters = new List<Parameter>();

        foreach (var option in options)
        {
            parameters.Add(new Parameter(option.Key, option.Value));
        }

        FirebaseAnalytics.LogEvent(eventName, parameters.ToArray());
        Debug.Log(eventName + parameters);
    }
}