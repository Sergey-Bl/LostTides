using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            GameOver();
        }
        else if (collision.CompareTag("Treasure"))
        {
            // Логика для сбора сокровища
            CollectTreasure(collision.gameObject);
        }
    }

    private void GameOver()
    {
        // Логика для завершения игры
        Debug.Log("Game Over");
    }

    private void CollectTreasure(GameObject treasure)
    {
        // Логика для сбора сокровища
        Debug.Log("Treasure collected");
        Destroy(treasure);
    }
}