using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length; // Length of the object
    public GameObject cam; // Reference to the camera
    public float parallaxEffect; // Parallax effect multiplier

    public float moveSpeed = 0.5f; // Speed for "ew" tagged objects

    // Start is called before the first frame update
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x; // Get the width of the sprite
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the object is tagged with "ew"
        if (gameObject.tag == "Parallax")
        {
            // Move to the left continuously
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            // Looping logic: Check if the object has moved off-screen to the left
            if (transform.position.x < -length) // Adjust based on the left side of the screen
            {
                // Reset position to the right side of the screen
                Vector3 newPosition = new Vector3(transform.position.x + length * 2, transform.position.y, transform.position.z);
                transform.position = newPosition; // Reset position
            }
        }
        else
        {
            // Handle parallax adjustments for non-"ew" objects
            float dist = (cam.transform.position.x * parallaxEffect);
            transform.position = new Vector3(dist, transform.position.y, transform.position.z);
        }
    }
}
