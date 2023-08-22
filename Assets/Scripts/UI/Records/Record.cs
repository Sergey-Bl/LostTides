using TMPro;
using UnityEngine;

public class Record : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _recordText; // Ссылка на компонент TextMeshProUGUI для отображения рекорда.
    [SerializeField]
    private DistanceLoader _distanceLoader; // Ссылка на компонент DistanceLoader для загрузки длинного расстояния.

    public void DisplayRecords()
    {
        _distanceLoader.LoadLongestDistance(); // Загружаем длинное расстояние из сохраненных данных.
        float recordDistance = _distanceLoader.longestDistance; // Получаем длинное расстояние из DistanceLoader.
        string recordsString = $"YOUR RECORD: {recordDistance:#}m"; // Формируем строку для отображения рекорда.

        _recordText.text = recordsString; // Присваиваем сформированную строку компоненту TextMeshProUGUI для отображения рекорда.
    }

    private void Start()
    {
        DisplayRecords(); // Вызываем метод DisplayRecords() при запуске компонента для отображения рекорда.
    }
}