using UnityEngine;

public class BuyManager : MonoBehaviour
{
    [SerializeField] private
        ShopManager shopManager;
    [SerializeField] private
        CoinCollect coinCollect;
    [SerializeField] private
        ChangeFish changeFish;
    [SerializeField] private
        AbstractMetrics metrics;

    public void BuyFish(int fishIndex)
    {
        int fishPrice = shopManager.CalculateFishPrice(fishIndex);

        if (coinCollect.Coins < fishPrice) return;

        metrics.Send("BuyFISH");

        coinCollect.Coins -= fishPrice;
        shopManager.SavePlayerData();
        shopManager._coinText.text = $"x{coinCollect.Coins}";
        shopManager.UpdateFishMesh(fishIndex);

        Mesh newFishMesh = shopManager.GetCurrentFishMesh();

        if (newFishMesh != null)
        {
            changeFish.ApplyNewFishMesh(newFishMesh);
        }
    }
}