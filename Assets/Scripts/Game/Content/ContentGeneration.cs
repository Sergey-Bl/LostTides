using UnityEngine;

public class ContentGeneration : MonoBehaviour
{
    
    // НУЖНО ВСЕ ДОРАБАТЫВАТЬ / СЕЙЧАС  НЕ РАБОТАЕТ
    public float maxDepth = -10f; // Максимальная глубина
    public float obstacleSpawnInterval = 2f; // Интервал появления препятствий
    public float treasureSpawnInterval = 4f; // Интервал появления сокровищ

    public GameObject obstaclePrefab;
    public GameObject treasurePrefab;

    private float obstacleTimer;
    private float treasureTimer;

    private void Update()
    {
        MoveDown();
        SpawnObstacles();
        SpawnTreasures();
    }

    private void MoveDown()
    {
        if (transform.position.y > maxDepth)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
    }

    private void SpawnObstacles()
    {
        obstacleTimer += Time.deltaTime;
        if (obstacleTimer >= obstacleSpawnInterval)
        {
            float randomX = Random.Range(-3f, 3f);
            
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            obstacleTimer = 0f;
        }
    }

    private void SpawnTreasures()
    {
        treasureTimer += Time.deltaTime;
        if (treasureTimer >= treasureSpawnInterval)
        {
            // Вычисляем случайное смещение по оси X в пределах игрового поля
            float randomX = Random.Range(-3f, 3f);
            
            // Создаем сокровище на передней границе игрового поля с учетом случайного смещения
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);
            Instantiate(treasurePrefab, spawnPosition, Quaternion.identity);
            treasureTimer = 0f;
        }
    }
}