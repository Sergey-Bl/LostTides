using TMPro;
using UI.Game;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _coinField;
    [SerializeField]
    private SaveCoinsPref _saveCoinsPref;

    public int Coins;

    private void Start()
    {
        _saveCoinsPref.LoadCoins();
        UpdateCoinDisplay();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!collider2D.CompareTag("Coin")) return;
        AudioPlay audioPlay = GetComponent<AudioPlay>();
        audioPlay.collectSound();

        Destroy(collider2D.gameObject);

        Coins++;
        UpdateCoinDisplay();
        _saveCoinsPref.SaveCoins();
    }

    private void UpdateCoinDisplay()
    {
        _coinField.text = ($"x" + Coins);
    }
}