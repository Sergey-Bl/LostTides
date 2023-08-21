using UnityEngine;

namespace UI.Game
{
    public class SaveCoinsPref : MonoBehaviour
    {
        [SerializeField] 
        private CoinCollect _coinCollect;
        
        private const string CoinsKey = "Coins";

        public void SaveCoins()
        {
            PlayerPrefs.SetInt(CoinsKey, _coinCollect.Coins);
            PlayerPrefs.Save();
        }

        public void LoadCoins()
        {
            if (PlayerPrefs.HasKey(CoinsKey))
            {
                _coinCollect.Coins = PlayerPrefs.GetInt(CoinsKey);
            }
            else
            {
                _coinCollect.Coins = 0;
            }
        }
    }
}