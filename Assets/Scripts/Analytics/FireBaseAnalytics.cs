using System.Collections.Generic;
using Firebase.Analytics;
using System.Linq;

public class FireBaseAnalytics : AbstractMetrics
{
    public override void Send(string eventName, IReadOnlyDictionary<string, string> options)
    {
        FirebaseAnalytics.LogEvent(
            eventName,
            options
                .Select(e => new Parameter(e.Key, e.Value))
                .ToArray()
        );
    }
}