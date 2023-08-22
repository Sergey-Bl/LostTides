using System.Collections.Generic;
using Firebase.Analytics;

// Класс для отправки аналитики через Firebase Analytics
public class FireBaseAnalytics : AbstractMetrics
{
    // Переопределенный метод для отправки аналитического события с параметрами
    public override void Send(string eventName, IReadOnlyDictionary<string, string> options)
    {
        // Создание списка параметров для Firebase Analytics
        List<Parameter> parameters = new List<Parameter>();

        // Проход по всем параметрам и добавление их в список
        foreach (var option in options)
        {
            parameters.Add(new Parameter(option.Key, option.Value));
        }

        // Отправка аналитического события с параметрами в Firebase Analytics
        FirebaseAnalytics.LogEvent(eventName, parameters.ToArray());
    }
}