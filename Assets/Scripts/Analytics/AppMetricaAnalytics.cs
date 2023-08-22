using System.Collections.Generic;
using System.Linq;

// Класс для отправки аналитики через AppMetrica
public class AppMetricaAnalytics : AbstractMetrics
{
    // Переопределенный метод для отправки аналитического события с параметрами
    public override void Send(string eventName, IReadOnlyDictionary<string, string> options)
    {
        // Используем AppMetrica.Instance для отправки аналитического события с параметрами

        // Преобразование словаря параметров в формат, подходящий для AppMetrica
        var formattedOptions = options
            .Select(e => new KeyValuePair<string, object>(e.Key, e.Value))
            .ToDictionary(e => e.Key, e => e.Value);

        // Отправка аналитического события с параметрами в AppMetrica
        AppMetrica.Instance.ReportEvent(eventName, formattedOptions);
    }
}