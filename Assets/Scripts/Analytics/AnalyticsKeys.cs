// Подключение необходимых пространств имен
using System.Collections.Generic;
using UnityEngine;

// Пространство имен Metrics, содержащее класс AnalyticsKeys
namespace Metrics
{
    // Класс, отвечающий за аналитику ключей
    public class AnalyticsKeys : MonoBehaviour
    {
        // Поле для ссылки на компонент GameOver
        [SerializeField]
        private GameOver _gameOver;

        // Поле для ссылки на абстрактный компонент метрик
        [SerializeField]
        private AbstractMetrics _metrics;

        // Метод для отправки аналитики при завершении игры
        public void GameOverAnalytic()
        {
            // Создание словаря параметров для события "gameOver"
            var eventOptions = new Dictionary<string, string>
            {
                { "DeathCount", _gameOver.deadCount.ToString() }
            };

            // Отправка аналитики события "gameOver" с параметрами
            _metrics.Send("gameOver", eventOptions);
        }
    }
}