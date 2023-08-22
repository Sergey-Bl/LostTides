using System.Collections.Generic;
using UnityEngine;

// Класс для объединения нескольких компонентов метрик
public class SeveralMetrics : AbstractMetrics
{
    // Список компонентов метрик, в которых будет выполняться отправка
    [SerializeField] private List<AbstractMetrics> list = new();

    // Переопределенный метод для отправки аналитического события с параметрами
    public override void Send(string eventName, IReadOnlyDictionary<string, string> options)
    {
        // Проход по всем компонентам метрик из списка и отправка события в каждый из них
        foreach (var metrics in list)
        {
            metrics.Send(eventName, options);
        }
    }
}