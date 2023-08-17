using UnityEngine;
using UI.Game;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Button[] buyButtons;
    [SerializeField] private int[] fishPrices;

    [SerializeField] private CoinCollect coinCollect;
    [SerializeField] private SaveCoinsPref saveCoinsPref;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private Mesh[] fishMeshes;

    private int currentFishMeshIndex;

    private void Start()
    {
        LoadPlayerData();
        UpdateButtonInteractivity();
    }

    private void LoadPlayerData()
    {
        saveCoinsPref.LoadCoins();
    }

    private void SavePlayerData()
    {
        saveCoinsPref.SaveCoins();
    }

    private void UpdateButtonInteractivity()
    {
        // ... (остальной код)
    }

    public void BuyFish(int fishIndex)
    {
        int fishPrice = CalculateFishPrice(fishIndex);
        if (coinCollect.Coins >= fishPrice)
        {
            coinCollect.Coins -= fishPrice;
            SavePlayerData();

            coinText.text = $"x{coinCollect.Coins}";

            UpdateFishMesh(fishIndex);

            Mesh newFishMesh = GetCurrentFishMesh();
            if (newFishMesh != null)
            {
                playerController.ApplyNewFishMesh(newFishMesh);
            }
        }
    }
    

    private int CalculateFishPrice(int fishIndex)
    {
        return fishPrices[fishIndex];
    }

    private void UpdateFishMesh(int fishIndex)
    {
        if (fishIndex < fishMeshes.Length)
        {
            currentFishMeshIndex = fishIndex;
        }
    }

    public Mesh GetCurrentFishMesh()
    {
        if (currentFishMeshIndex < fishMeshes.Length)
        {
            return fishMeshes[currentFishMeshIndex];
        }
        return null;
    }

    public void FreezWhenOpenWindow()
    {
        Time.timeScale = 0f;
    }
}