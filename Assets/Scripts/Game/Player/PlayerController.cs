using UI.Player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UpdateDisplayDistance updateDisplayDistance;
    [SerializeField] private DistanceLoader distanceLoader;

    [SerializeField] private float forwardSpeed = 5f;
    [SerializeField] private float tapForce = 10f;
    
    [SerializeField] private GameObject _tutorText;

    [SerializeField] private GameOver gameOver;
    [SerializeField] private Record record;
    [SerializeField] private ChangeFish changeFish;

    private bool waitingForInput = true;

    private Rigidbody2D rb;
    public float distanceTraveled;

    private SkinnedMeshRenderer fishSkinnedMeshRenderer;

    private int defaultFishMeshIndex = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        changeFish.fishMeshFilter = GetComponent<MeshFilter>();
    }

    private void Start()
    {
        AppMetrica.Instance.ReportEvent("LevelStarted");

        distanceLoader.LoadLongestDistance();
        updateDisplayDistance.UpdateDistanceDisplay();

        record.DisplayRecords();
        
        rb.velocity = Vector2.zero; 
        rb.gravityScale = 0f; 
    }

    private void Update()
    {
        if (waitingForInput)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _tutorText.SetActive(false);
                waitingForInput = false;
                rb.gravityScale = 1f; 
                rb.velocity = Vector2.zero; 
            }
        }
        else
        {
            rb.velocity = new Vector2(forwardSpeed, rb.velocity.y);

            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector2(rb.velocity.x, tapForce);
            }

            distanceTraveled += forwardSpeed * Time.deltaTime;
            updateDisplayDistance.UpdateDistanceDisplay();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            gameOver.HandleGameOver();
        }
    }
}
