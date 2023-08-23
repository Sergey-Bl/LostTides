using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI _coinText;

    [SerializeField]
    private int[] fishPrices;
    [SerializeField]
    private SaveCoinsPref saveCoinsPref;
    [SerializeField]
    private Mesh[] fishMeshes;

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