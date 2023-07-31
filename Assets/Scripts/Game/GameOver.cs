using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject restartPopUp;
    [SerializeField] private TextMeshProUGUI _deadCountField;
    
    private int deadCount;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            HandleGameOver();
        }
    }

    private void HandleGameOver()
    {
        Debug.Log("Game Over");
        restartPopUp.SetActive(true);
        Time.timeScale = 0f;
        //нужно дописать чтобы при рестарте уровней оставалось кол-во смертей
        deadCount++;
        _deadCountField.text = ($"x" + deadCount);
    }
}