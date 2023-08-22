using System.Collections.Generic;
using UnityEngine;

// Абстрактный базовый класс для метрик и аналитики
public abstract class AbstractMetrics : MonoBehaviour
{
    // Создание пустого словаря для параметров
    private readonly IReadOnlyDictionary<string, string> _emptyOptions = new Dictionary<string, string>();

    // Абстрактный метод для отправки метрики или аналитики с параметрами
    public abstract void Send(string eventName, IReadOnlyDictionary<string, string> options);

    // Метод для отправки метрики или аналитики без параметров (использует пустой словарь)
    public void Send(string eventName)
    {
        Send(eventName, _emptyOptions);
    }
}