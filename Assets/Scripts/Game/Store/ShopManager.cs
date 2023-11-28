using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _coinText;
    [SerializeField] private CoinCollect _coinCollect;
    [SerializeField] private int[] fishPrices;
    [SerializeField] private SkinnedMeshRenderer[] fishRenderers; // Массив для SkinnedMeshRenderer
    [SerializeField] private GameObject[] fishObjects; // Массив для объектов рыб

    [SerializeField]private int currentFishMeshIndex;

    private void Start()
    {
        LoadPlayerData();
        currentFishMeshIndex = 0; // Инициализируем индекс текущей рыбы
        UpdateFishMesh(currentFishMeshIndex); // Отображаем первую рыбу
    }

    private void LoadPlayerData()
    {
        _coinCollect.LoadCoins();
    }

    public void SavePlayerData()
    {
        _coinCollect.SaveCoins();
    }

    public int CalculateFishPrice(int fishIndex)
    {
        return fishPrices[fishIndex];
    }

    public void UpdateFishMesh(int fishIndex)
    {
        if (fishIndex < fishRenderers.Length)
        {
            // Скрываем текущую рыбу
            fishObjects[currentFishMeshIndex].SetActive(false);

            // Отображаем новую рыбу
            fishObjects[fishIndex].SetActive(true);

            currentFishMeshIndex = fishIndex;
        }
    }

    public SkinnedMeshRenderer GetCurrentFishRenderer()
    {
        return currentFishMeshIndex < fishRenderers.Length ? fishRenderers[currentFishMeshIndex] : null;
    }

    public void FreezeWhenOpenWindow()
    {
        Time.timeScale = 0f;
    }
}