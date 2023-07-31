using TMPro;
using UnityEngine;

namespace UI.Game
{
    public class CoinCollect : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI _coinField;
        private int Coins;
        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Coin"))
            {
                Destroy(collider2D.gameObject);
                Coins++;
                _coinField.text = ($"x"+Coins);
            }
        }
    }
}