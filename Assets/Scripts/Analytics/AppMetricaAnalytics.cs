using System.Collections.Generic;
using System.Linq;

public class AppMetricaAnalytics : AbstractMetrics
{
    public override void Send(string eventName, IReadOnlyDictionary<string, string> options)
    {
        var formattedOptions = options
            .Select(e => new KeyValuePair<string, object>(e.Key, e.Value))
            .ToDictionary(e => e.Key, e => e.Value);

        AppMetrica.Instance.ReportEvent(eventName, formattedOptions);
    }
}