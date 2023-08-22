using UnityEngine;

// Класс для сохранения и загрузки количества монет
public class SaveCoinsPref : MonoBehaviour
{
    // Ссылка на компонент сбора монет
    [SerializeField]
    private CoinCollect _coinCollect;

    // Ключ для сохранения количества монет
    private const string CoinsKey = "Coins";

    // Сохранение количества монет в PlayerPrefs
    public void SaveCoins()
    {
        PlayerPrefs.SetInt(CoinsKey, _coinCollect.Coins);
        PlayerPrefs.Save();
    }

    // Загрузка количества монет из PlayerPrefs
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