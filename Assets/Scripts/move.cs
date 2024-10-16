using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    // Health Bar
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Movement
    private Rigidbody2D rb;
    private Vector2 playerVelocity;
    public float playerSpeed = 5.0f;
    public float jumpHeight = 5.0f; 
    public float gravityValue = -9.81f;
    public bool canDoubleJump = false;
    private bool jumpCharge = false;
    private bool releaseJump = false;
    private bool flipped = false;

    // Ground Checking
    private bool isGrounded;
    public Transform groundCheck;  // Reference to the empty GameObject below player's feet
    public float groundCheckRadius = 0.2f;  // Size of the ground check circle
    public LayerMask groundLayer;  // Ground layer for detection

    // Teleporter
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
        // Health Bar
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(20);
        //}
        if (currentHealth == 0)
        {
            SceneManager.LoadSceneAsync(1);
        }
        if (Input.GetKeyDown(KeyCode.A) && flipped == false)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = !spriteRenderer.flipX;
            flipped = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) && flipped == true)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = !spriteRenderer.flipX;
            flipped = false;
        }


        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * playerSpeed, rb.velocity.y);

        // Jumping logic
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (canDoubleJump) {
            if (!isGrounded && Input.GetAxis("Vertical") == 0) {
                releaseJump = true;
            } else if (isGrounded) {
                jumpCharge = true;
            }
        }
        if ((Input.GetAxis("Vertical") > 0 && isGrounded) || (canDoubleJump && releaseJump && jumpCharge && Input.GetAxis("Vertical") > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sqrt(jumpHeight * -2.0f * gravityValue));
            releaseJump = false;
            if (!isGrounded) {
                jumpCharge = false;
            }
        }

        // Teleporter
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
        if (collider.CompareTag("Rat"))
        {
            TakeDamage(20);
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
