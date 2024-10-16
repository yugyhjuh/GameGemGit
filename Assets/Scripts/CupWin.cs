using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupWin : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Sprite closed;
    public Sprite open;
    private bool shut = false;

    private float startTime;

    void Start() {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        startTime = Time.time;
    }

    void Update() {
        if (Time.time - startTime > 5 && !shut) {
            sr.sprite = closed;
            shut = true;
        }
    }

    void OnMouseDown() {
        Debug.Log("WINNNNEEEEERRRRRR");
        rb.MoveRotation(0);
        sr.sprite = open;
        rb.velocity = new Vector2(0f,0f);
        rb.Sleep();
    }
}
