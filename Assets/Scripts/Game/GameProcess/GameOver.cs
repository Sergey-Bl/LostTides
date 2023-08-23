using Metrics; // Импорт пространства имен Metrics для доступа к компонентам метрик
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _deadCountField; // Поле для отображения количества смертей
    [SerializeField]
    private GameObject restartPopUp; // Объект всплывающего окна после завершения игры
    [SerializeField]
    private PlayerController _playerController; // Ссылка на компонент управления игроком
    [SerializeField]
    private AnalyticsKeys _analyticsKeys; // Ссылка на компонент для аналитики
    [SerializeField]
    private SaveCountDead _saveCountDead; // Ссылка на компонент для сохранения количества смертей
    [SerializeField]
    private UpdateDisplayDistance _updateDisplayDistance; // Ссылка на компонент для обновления отображения дистанции
    [SerializeField]
    private DistanceLoader _distanceLoader; // Ссылка на компонент для загрузки дистанции

    internal const string DeadCountKey = "DeadCount"; // Ключ для сохранения количества смертей в PlayerPrefs
    public int deadCount; // Текущее количество смертей

    private void Start()
    {
        _saveCountDead.LoadDeadCount(); // Загрузка количества смертей из сохранений
        UpdateDeadCountDisplay(); // Обновление отображения количества смертей
    }

    public void GameOverInit()
    {
        restartPopUp.SetActive(true); // Активация всплывающего окна

        deadCount++;
        UpdateDeadCountDisplay(); // Обновление отображения количества смертей
        _saveCountDead.SaveDeadCount(); // Сохранение количества смертей

        _distanceLoader.SaveLongestDistance(); // Сохранение наибольшей дистанции

        _analyticsKeys.GameOverAnalytic(); // Вызов метода аналитики для завершения игры

        AudioPlay audioPlay = GetComponent<AudioPlay>(); // Получение компонента воспроизведения аудио
        audioPlay.musicStop(); // Остановка музыки
        audioPlay.gameOverSound(); // Воспроизведение звука завершения игры

        Time.timeScale = 0f; // Остановка времени игры
    }

    internal void UpdateDeadCountDisplay()
    {
        _deadCountField.text = $"x{deadCount}"; //Использовать Интерполяцию // Обновление текста с отображением количества смертей
    }

    public void HandleGameOver()
    {
        if (_playerController.distanceTraveled > _distanceLoader.longestDistance)
        {
            _distanceLoader.longestDistance = _playerController.distanceTraveled;
            _distanceLoader.SaveLongestDistance();
        }

        _updateDisplayDistance.UpdateDistanceDisplay(); // Обновление отображения дистанции
        _updateDisplayDistance.UpdateDistanceWhenLose(); // Обновление дистанции при проигрыше

        GameOverInit(); // Вызов метода инициализации завершения игры
    }
}