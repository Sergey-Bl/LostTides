using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5f; 
    [SerializeField] private float tapForce = 10f;
    
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AppMetrica.Instance.ReportEvent("appStarted");
    }

    private void Update()
    {
        rb.velocity = new Vector2(forwardSpeed, rb.velocity.y);

        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log("Click display");
            rb.velocity = new Vector2(rb.velocity.x, tapForce);
        }
        
    }
    
}