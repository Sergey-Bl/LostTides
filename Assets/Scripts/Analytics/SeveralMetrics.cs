using System.Collections.Generic;
using UnityEngine;

public class SeveralMetrics : AbstractMetrics
{
    [SerializeField] private
        List<AbstractMetrics> list = new();

    public override void Send(string eventName, IReadOnlyDictionary<string, string> options)
    {
        foreach (var metrics in list)
        {
            metrics.Send(eventName, options);
        }
    }
}