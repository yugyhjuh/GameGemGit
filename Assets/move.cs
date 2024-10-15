using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{ 
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private bool isGrounded;
    public Transform groundCheck;  // Reference to the empty GameObject below player's feet
    public float groundCheckRadius = 5.0f;  // Size of the ground check circle
    public LayerMask groundLayer;

    

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        if (Input.GetAxis("Vertical") > 0 && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -5.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


    }
}
