using UnityEngine;
using UI.Game;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI coinText;
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
    }

    private void LoadPlayerData()
    {
        saveCoinsPref.LoadCoins();
    }

    public void SavePlayerData()
    {
        saveCoinsPref.SaveCoins();
    }

    public int CalculateFishPrice(int fishIndex)
    {
        return fishPrices[fishIndex];
    }

    public void UpdateFishMesh(int fishIndex)
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

    public void FreezeWhenOpenWindow()
    {
        Time.timeScale = 0f;
    }
}