using UnityEngine;

// Класс для обработки аналитики при нажатии на кнопки в меню
public class MenuAlatyticsButtons : MonoBehaviour
{
    // Ссылка на абстрактный компонент метрик
    [SerializeField]
    private AbstractMetrics metrics;

    // Метод для отправки аналитики при нажатии на кнопку Play в меню уровня 1
    // Очень нестабильная связь между кнопкой и отправкой метрики, не рекомендую делать большую логику на стороне едитора, лучше использовать декоратор 
    public void PlayTap()
    {
        metrics.Send("playButtonTapLevel1");
    }

    // Метод для отправки аналитики при нажатии на кнопку Play в меню уровня 2
    public void PlayTapLevel2()
    {
        metrics.Send("playButtonTapLevel2");
    }

    // Метод для отправки аналитики при нажатии на кнопку Setting в меню
    public void SettingTap()
    {
        metrics.Send("settingButtonTap");
    }

    // Метод для отправки аналитики при нажатии на кнопку Store в меню
    public void StoreTap()
    {
        metrics.Send("storeButtonTap");
    }
}