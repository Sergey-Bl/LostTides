using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject Level2Button; // Ссылка на игровой объект кнопки для уровня 2.

    private void Start()
    {
        // Проверяем, пройден ли уровень 1.
        if (LevelProgress.IsLevel1Passed())
        {
            // Если уровень 1 пройден, активируем кнопку для уровня 2.
            Level2Button.SetActive(true);
        }
    }
}