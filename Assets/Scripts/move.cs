using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private Rigidbody2D rb;
    private Vector2 playerVelocity;
    public float playerSpeed = 5.0f;
    public float jumpHeight = 5.0f;  // Jump force (use higher value for 2D jumping)
    public float gravityValue = -9.81f;  // Default gravity for 2D physics

    private bool isGrounded;
    public Transform groundCheck;  // Reference to the empty GameObject below player's feet
    public float groundCheckRadius = 0.2f;  // Size of the ground check circle
    public LayerMask groundLayer;  // Ground layer for detection

    private GameObject currentTeleporter;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        rb = gameObject.GetComponent<Rigidbody2D>();  // Add Rigidbody2D component
        rb.gravityScale = 1;  // Set gravity scale for 2D
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        // Check if player is grounded by using Physics2D.OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * playerSpeed, rb.velocity.y);  // Set horizontal velocity

        // Jumping logic
        if (Input.GetAxis("Vertical") > 0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sqrt(jumpHeight * -2.0f * gravityValue));
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;

            }
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Teleporter"))
        {
            currentTeleporter = collider.gameObject;
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Teleporter"))
        {
            if (collider.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
