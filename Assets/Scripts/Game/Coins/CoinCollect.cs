using TMPro;
using UnityEngine;

// Класс для управления сбором монет
public class CoinCollect : MonoBehaviour
{
    // Поле для отображения количества монет
    // Не очень хорошо что бизнес класс знает про UI, лучше сделать событие UnityEvent<int> onCountUpdate где подписывается UI
    [SerializeField]
    private TextMeshProUGUI _coinField;

    // Ссылка на компонент сохранения количества монет
    [SerializeField]
    private SaveCoinsPref _saveCoinsPref;

    // Количество собранных монет
    public int Coins;

    // Вызывается при старте объекта
    private void Start()
    {
        // Загрузка сохраненного количества монет
        _saveCoinsPref.LoadCoins();
        // Обновление отображения монет
        UpdateCoinDisplay();
    }

    // Вызывается при соприкосновении объекта с коллайдером
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        // Проверка, что объект имеет тег "Coin"
        if (!collider2D.CompareTag("Coin")) return;

        // Воспроизведение звука сбора монеты
        AudioPlay audioPlay = GetComponent<AudioPlay>();
        audioPlay.collectSound();

        // Уничтожение монеты
        Destroy(collider2D.gameObject);

        // Увеличение счетчика монет и обновление отображения
        Coins++;
        UpdateCoinDisplay();

        // Сохранение количества монет
        _saveCoinsPref.SaveCoins();
    }

    // Обновление отображения количества монет
    private void UpdateCoinDisplay()
    {
        _coinField.text = ($"x" + Coins);
    }
}