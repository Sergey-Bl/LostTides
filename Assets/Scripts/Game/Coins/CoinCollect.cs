using TMPro;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private
        TextMeshProUGUI _coinField;

    public int Coins;

    private const string CoinsKey = "Coins";

    private void Start()
    {
        LoadCoins();
        UpdateCoinDisplay();
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!collider2D.CompareTag("Coin")) return;

        AudioPlay audioPlay = GetComponent<AudioPlay>();
        audioPlay.collectSound();

        Destroy(collider2D.gameObject);

        Coins++;
        UpdateCoinDisplay();

        SaveCoins();
    }

    private void UpdateCoinDisplay()
    {
        _coinField.text = ($"x" + Coins);
    }

    internal void SaveCoins()
    {
        PlayerPrefs.SetInt(CoinsKey, Coins);
        PlayerPrefs.Save();
    }

    internal void LoadCoins()
    {
        Coins = PlayerPrefs.HasKey(CoinsKey) ? PlayerPrefs.GetInt(CoinsKey) : 0;
    }
}