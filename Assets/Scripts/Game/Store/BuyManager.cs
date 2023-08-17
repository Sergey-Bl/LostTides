using UI.Player;
using UnityEngine;

namespace UI.Store
{
    public class BuyManager : MonoBehaviour
    {
        [SerializeField] private ShopManager shopManager;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private CoinCollect coinCollect;
        [SerializeField] private ChangeFish changeFish;
        
        
        
        public void BuyFish(int fishIndex)
    {
        int fishPrice = shopManager.CalculateFishPrice(fishIndex);
        if (coinCollect.Coins >= fishPrice)
        {
            AppMetrica.Instance.ReportEvent("BuyFISH");
            coinCollect.Coins -= fishPrice;
            shopManager.SavePlayerData();

            shopManager.coinText.text = $"x{coinCollect.Coins}";

            shopManager.UpdateFishMesh(fishIndex);

            Mesh newFishMesh = shopManager.GetCurrentFishMesh();
            if (newFishMesh != null)
            {
                changeFish.ApplyNewFishMesh(newFishMesh);
            }
        }
    }
    }
}