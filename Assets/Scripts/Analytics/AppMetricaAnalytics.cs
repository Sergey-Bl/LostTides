using UnityEngine;

public class AppMetricaAnalytics : Analytics
{
    public override void SendEvent(string eventName)
    {
        AppMetrica.Instance.ReportEvent(eventName);
        Debug.Log("Отправка события " + eventName + " в AppMetrica");
    }
}