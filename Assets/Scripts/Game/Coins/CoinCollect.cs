using DefaultNamespace;
using TMPro;
using UnityEngine;

namespace UI.Game
{
    public class CoinCollect : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinField;

        private int Coins;

        private const string CoinsKey = "Coins";

        private void Start()
        {
            LoadCoins();
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
                SaveCoins();
            }
        }

        private void UpdateCoinDisplay()
        {
            _coinField.text = ($"x" + Coins);
        }

        private void SaveCoins()
        {
            PlayerPrefs.SetInt(CoinsKey, Coins);
            PlayerPrefs.Save();
        }

        private void LoadCoins()
        {
            if (PlayerPrefs.HasKey(CoinsKey))
            {
                Coins = PlayerPrefs.GetInt(CoinsKey);
            }
            else
            {
                Coins = 0;
            }
        }
    }
}