using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{   
    public float bounceForce = 10f;  // Force applied on bounce

    private Rigidbody2D rb;  // Reference to the Rigidbody2D component

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component attached to the object
        rb = GetComponent<Rigidbody2D>();
    }

    // Detect collision with other objects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = new Vector2(Random.Range(-30.0f, 30.0f), Random.Range(-30.0f, 30.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.IsAwake() && this.gameObject.transform.parent.gameObject.GetComponent<Cups>().bouncing) {
            if ((-1 < rb.velocity.x && rb.velocity.x < 1) || (-1 < rb.velocity.y && rb.velocity.y < 1)) {
                rb.velocity = new Vector2(Random.Range(-30.0f, 30.0f), Random.Range(-30.0f, 30.0f));
            }
        }
    }
}
