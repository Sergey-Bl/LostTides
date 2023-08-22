using UnityEngine;

public class WinLevel : MonoBehaviour
{
    [SerializeField] 
    private GameObject winPopUp;
    
    [SerializeField]
    private AbstractMetrics metrics;

    /// <summary>
    /// Обработчик события столкновения объектов.
    /// </summary>
    /// <param name="collision">Данные о столкновении.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, что столкновение произошло с объектом с тегом "Win".
        if (!collision.collider.CompareTag("Win")) return;

        // Отправляем аналитику о победе.
        metrics.Send("WinLevel1");

        // Вызываем метод для обработки победы.
        HandleWin();
    }

    /// <summary>
    /// Обработчик победы.
    /// </summary>
    private void HandleWin()
    {
        // Активируем всплывающее окно победы.
        winPopUp.SetActive(true);

        // Устанавливаем, что уровень 1 пройден.
        LevelProgress.SetLevel1Passed(true);
    }
}