using UnityEngine;

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
        _coinCollect.Coins = PlayerPrefs.HasKey(CoinsKey) ? PlayerPrefs.GetInt(CoinsKey) : 0;
    }
}