using UnityEngine;

// Класс для сброса счетчиков
public class CountReset : MonoBehaviour
{
    private GameOver gameOver; // Ссылка на компонент завершения игры

    [SerializeField]
    private AbstractMetrics metrics; // Ссылка на компонент метрик

    // Метод для сброса счетчика количества смертей
    public void ResetDeadCount()
    {
        metrics.Send("DeadCountResetTap"); // Отправка метрики о нажатии кнопки сброса счетчика смертей
        PlayerPrefs.DeleteKey(GameOver.DeadCountKey); // Удаление ключа счетчика смертей из PlayerPrefs
    }

    // Метод для сброса счетчика дистанции
    public void ResetDistance()
    {
        metrics.Send("DistanceCountResetTap"); // Отправка метрики о нажатии кнопки сброса счетчика дистанции
        PlayerPrefs.DeleteKey(DistanceLoader.LongestDistanceKey); // Удаление ключа счетчика дистанции из PlayerPrefs
    }
}