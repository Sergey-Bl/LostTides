using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject restartPopUp;

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
    }
}