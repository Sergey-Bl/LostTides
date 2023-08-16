using UnityEngine;

namespace UI.Game
{
    public class SaveCoinsPref : MonoBehaviour
    {
        [SerializeField] private CoinCollect coinCollect;
        private const string CoinsKey = "Coins";

        public void SaveCoins()
        {
            PlayerPrefs.SetInt(CoinsKey, coinCollect.Coins);
            PlayerPrefs.Save();
        }

        public void LoadCoins()
        {
            if (PlayerPrefs.HasKey(CoinsKey))
            {
                coinCollect.Coins = PlayerPrefs.GetInt(CoinsKey);
            }
            else
            {
                coinCollect.Coins = 0;
            }
        }
    }
}