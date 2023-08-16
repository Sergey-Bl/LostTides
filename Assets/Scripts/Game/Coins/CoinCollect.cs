using DefaultNamespace;
using TMPro;
using UI.Game;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinField;
    [SerializeField] private SaveCoinsPref saveCoinsPref;

    public int Coins { get; set; } = 0;


    private void Start()
    {
        saveCoinsPref.LoadCoins();
        UpdateCoinDisplay();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Coin"))
        {
            AudioPlay audioPlay = GetComponent<AudioPlay>();
            audioPlay.collectSound();

            Destroy(collider2D.gameObject);

            Coins++;
            UpdateCoinDisplay();
            saveCoinsPref.SaveCoins();
        }
    }

    private void UpdateCoinDisplay()
    {
        _coinField.text = ($"x" + Coins);
    }
}