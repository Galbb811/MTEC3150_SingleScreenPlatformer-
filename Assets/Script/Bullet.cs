//using System.Drawing;
using UnityEngine;

public class Bullet: MonoBehaviour
{
   [HideInInspector] public float speed = 10;
   [HideInInspector] public Vector2 direction;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
   [HideInInspector] public Color col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.color = col;
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed * Time.deltaTime;
        
    }
}
