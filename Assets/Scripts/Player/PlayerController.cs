using System;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5f; 
    [SerializeField] private float tapForce = 10f;
    
    [SerializeField] private GameOver gameOver;
    
    private Rigidbody2D rb;
    private float distanceTraveled = 0f;
    private float longestDistance = 0f;
    
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI longestDistanceText;

    private const string LongestDistanceKey = "LongestDistance";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AppMetrica.Instance.ReportEvent("appStarted");
        LoadLongestDistance();
        UpdateDistanceDisplay();
    }

    private void Update()
    {
        rb.velocity = new Vector2(forwardSpeed, rb.velocity.y);

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, tapForce);
        }
    
        distanceTraveled += forwardSpeed * Time.deltaTime;
        UpdateDistanceDisplay();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            HandleGameOver(); 
        }
    }


    private void UpdateDistanceDisplay()
    {
        distanceText.text = $"{distanceTraveled:F2}";
        longestDistanceText.text = $"Best {longestDistance:F2}";
    }

    private void HandleGameOver()
    {
        if (distanceTraveled > longestDistance)
        {
            longestDistance = distanceTraveled;
            SaveLongestDistance();
        }

        distanceTraveled = 0f;
        UpdateDistanceDisplay();

        // Вызываем метод обработки проигрыша в классе GameOver
        gameOver.HandleGameOver();
    }

    private void SaveLongestDistance()
    {
        PlayerPrefs.SetFloat(LongestDistanceKey, longestDistance);
        PlayerPrefs.Save();
    }

    private void LoadLongestDistance()
    {
        if (PlayerPrefs.HasKey(LongestDistanceKey))
        {
            longestDistance = PlayerPrefs.GetFloat(LongestDistanceKey);
        }
        else
        {
            longestDistance = 0f;
        }
    }
}
