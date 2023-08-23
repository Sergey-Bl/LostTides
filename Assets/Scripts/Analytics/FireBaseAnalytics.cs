using System.Collections.Generic;
using System.Linq;
using Firebase.Analytics;

// Класс для отправки аналитики через Firebase Analytics

//Рекомендую сохранять стркутуру назвнания для удобства:
//либо FireBaseAnalytics : AbstractAnalytics
//либо FireBaseMetrics : AbstractMetrics
public class FireBaseAnalytics : AbstractMetrics
{
    //Можно меньше комментариев, хороший код говорит сам за себя
    // Переопределенный метод для отправки аналитического события с параметрами
    public override void Send(string eventName, IReadOnlyDictionary<string, string> options)
    {
        //в этом случае можно использовать linq
        FirebaseAnalytics.LogEvent(
            eventName,
            options
                .Select(e => new Parameter(e.Key, e.Value))
                .ToArray()
        );
    }
}