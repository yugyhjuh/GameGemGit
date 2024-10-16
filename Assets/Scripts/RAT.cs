using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAT : MonoBehaviour
{
    private Rigidbody2D rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = 20f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = new Vector2(Random.Range(-30.0f, 30.0f), Random.Range(-30.0f, 30.0f));
        rb.angularVelocity = Random.Range(-3000f, 3000f);
        float randScale = Random.Range(0.5f, 3.5f);
        this.gameObject.transform.localScale = new Vector3(randScale, randScale, randScale);
    }

    void Update()
    {
        if ((-1 < rb.velocity.x && rb.velocity.x < 1) || (-1 < rb.velocity.y && rb.velocity.y < 1)) 
        {
                rb.velocity = new Vector2(Random.Range(-30.0f, 30.0f), Random.Range(-30.0f, 30.0f));
        }
    }
}
