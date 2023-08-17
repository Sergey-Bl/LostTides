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
    [SerializeField] private ShopManager shopManager;

    private Rigidbody2D rb;
    public float distanceTraveled;

    private MeshFilter fishMeshFilter;
    private SkinnedMeshRenderer fishSkinnedMeshRenderer;

    private int defaultFishMeshIndex = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        fishMeshFilter = GetComponent<MeshFilter>();
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

    public void ApplyNewFishMesh(Mesh newMesh)
    {
        if (fishMeshFilter != null)
        {
            fishMeshFilter.mesh = newMesh;

            transform.localScale = new Vector3(0.5285938f, 0.7903844f, 2f); // Примерный масштаб
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                boxCollider.size = new Vector2(1.01f, 0.43f);
                boxCollider.offset = new Vector2(-0.04f, 0f);
            }
        }
    }
}