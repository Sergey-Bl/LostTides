using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI _coinText;

    [SerializeField] private
        CoinCollect _coinCollect;
    [SerializeField] private int[]
        fishPrices;
    [SerializeField] private Mesh[]
        fishMeshes;

    private int
        currentFishMeshIndex;

    private void Start()
    {
        LoadPlayerData();
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
        if (fishIndex < fishMeshes.Length)
        {
            currentFishMeshIndex = fishIndex;
        }
    }

    public Mesh GetCurrentFishMesh()
    {
        return currentFishMeshIndex < fishMeshes.Length ? fishMeshes[currentFishMeshIndex] : null;
    }

    public void FreezeWhenOpenWindow()
    {
        Time.timeScale = 0f;
    }
}