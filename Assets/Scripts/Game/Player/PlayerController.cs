using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float forwardSpeed = 5f;
    [SerializeField]
    private float tapForce = 10f;
    [SerializeField]
    private GameObject _tutorText;
    [SerializeField]
    private UpdateDisplayDistance _updateDisplayDistance;
    [SerializeField]
    private DistanceLoader _distanceLoader;
    [SerializeField]
    private GameOver _gameOver;
    [SerializeField]
    private Record _record;
    [SerializeField]
    private ChangeFish _changeFish;
    [SerializeField]
    private AbstractMetrics metrics;

    private bool waitingForInput = true;
    private Rigidbody2D rb;
    private int defaultFishMeshIndex = 0;
    private AudioPlay _audioPlay;

    public float distanceTraveled { private set; get; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _changeFish.fishMeshFilter = GetComponent<MeshFilter>();
    }

    private void Start()
    {
        _audioPlay = GetComponent<AudioPlay>();

        // Отправляем аналитику о начале уровня.
        metrics.Send("level_started");

        // Загружаем длину самого длинного пройденного расстояния и обновляем его отображение.
        _distanceLoader.LoadLongestDistance();
        _updateDisplayDistance.UpdateDistanceDisplay();

        // Отображаем рекорды.
        _record.DisplayRecords();

        // Обнуляем скорость и гравитацию в начале.
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
    }

    private void Update()
    {
        if (waitingForInput)
        {
            if (!Input.GetMouseButtonDown(0)) return;

            // Отключаем подсказку и активируем движение игрока.
            _tutorText.SetActive(false);
            waitingForInput = false;
            rb.gravityScale = 1f;
            rb.velocity = Vector2.zero;

            // Запускаем фоновую музыку.
            _audioPlay.backGroundSound();
        }
        else
        {
            // Движение игрока вперед.
            rb.velocity = new Vector2(forwardSpeed, rb.velocity.y);

            // Проигрываем анимацию прыжка при нажатии на экран.
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector2(rb.velocity.x, tapForce);
            }

            // Обновляем пройденное расстояние.
            distanceTraveled += forwardSpeed * Time.deltaTime;
            _updateDisplayDistance.UpdateDistanceDisplay();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Обработка столкновения с препятствием.
        if (collision.collider.CompareTag("Obstacle"))
        {
            _gameOver.HandleGameOver();
        }
    }
}