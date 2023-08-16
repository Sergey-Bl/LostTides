using UnityEngine;
using UI.Player;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UpdateDisplayDistance updateDisplayDistance;
    [SerializeField] private DistanceLoader distanceLoader;

    [SerializeField] private float forwardSpeed = 5f;
    [SerializeField] private float tapForce = 10f;

    [SerializeField] private GameOver gameOver;
    [SerializeField] private Record record;

    private Rigidbody2D rb;
    public float distanceTraveled;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AppMetrica.Instance.ReportEvent("LevelStarted");

        distanceLoader.LoadLongestDistance();
        updateDisplayDistance.UpdateDistanceDisplay();

        record.DisplayRecords();
    }

    private void Update()
    {
        rb.velocity = new Vector2(forwardSpeed, rb.velocity.y);

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, tapForce);
        }

        distanceTraveled += forwardSpeed * Time.deltaTime;
        updateDisplayDistance.UpdateDistanceDisplay();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            gameOver.HandleGameOver();
        }
    }
    
}