using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI _coinText; // Текстовое поле для отображения количества монет.

    [SerializeField]
    private int[] fishPrices; // Массив цен на разные рыбы.
    [SerializeField]
    private SaveCoinsPref saveCoinsPref; // Ссылка на компонент сохранения монет.
    [SerializeField]
    private Mesh[] fishMeshes; // Массив мешей для разных рыб.

    private int currentFishMeshIndex; // Индекс текущего выбранного меша рыбы.

    private void Start()
    {
        LoadPlayerData(); // Загружаем данные игрока при старте.
    }

    private void LoadPlayerData()
    {
        saveCoinsPref.LoadCoins(); // Загружаем количество монет игрока.
    }

    public void SavePlayerData()
    {
        saveCoinsPref.SaveCoins(); // Сохраняем количество монет игрока.
    }

    public int CalculateFishPrice(int fishIndex)
    {
        return fishPrices[fishIndex]; // Возвращает цену для выбранной рыбы.
    }

    public void UpdateFishMesh(int fishIndex)
    {
        if (fishIndex < fishMeshes.Length)
        {
            currentFishMeshIndex = fishIndex; // Обновляем индекс текущего меша рыбы.
        }
    }

    public Mesh GetCurrentFishMesh()
    {
        if (currentFishMeshIndex < fishMeshes.Length)
        {
            return fishMeshes[currentFishMeshIndex]; // Возвращает текущий меш рыбы.
        }
        return null;
    }

    public void FreezeWhenOpenWindow()
    {
        Time.timeScale = 0f; // Замораживаем время при открытии окна магазина.
    }
}