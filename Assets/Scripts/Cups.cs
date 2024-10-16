using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cups : MonoBehaviour
{
    private Transform cupOne;
    private Transform cupTwo;
    private Transform cupTre;
    private Rigidbody2D rbOne;
    private Rigidbody2D rbTwo;
    private Rigidbody2D rbTre;
    private Rigidbody2D rb;
    public int bouncy = 0;
    public bool bouncing = false;
    private int kids;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        kids = this.gameObject.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("YAY");
            Shuffle();
            startTime = Time.time;
        }
        if (bouncing) {
            if (Time.time - startTime > 5) {
                Debug.Log("NOOOOO");
                bouncing = false;
                for (int i = 0; i < kids; i++) {
                    rb = this.gameObject.transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>();
                    rb.velocity = new Vector2(0f, 0f);
                    rb.Sleep();
                }
            } else {
                bouncy++;
            }
        }
    }

    void Shuffle() {
        bouncing = true;
        for (int i = 0; i < kids; i++) {
            rb = this.gameObject.transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>();
            rb.WakeUp();
            rb.velocity = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        }
    }
}
