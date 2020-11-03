using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMenuPlayer : MonoBehaviour
{
    private float dirX, speed = 250f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    private void Start()
    {
        if (sr.flipX)
        {
            dirX = -1.5f;
        }
        else
        {
            dirX = 1.5f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        SetMove(dirX);
    }

    void SetMove(float x)
    {
        rb.velocity = new Vector2(x, 0) * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemie"))
        {
            if (sr.flipX)
            {
                sr.flipX = false;
                dirX = 1.5f;
            }
            else
            {
                sr.flipX = true;
                dirX = -1.5f;
            }
        }
    }
}
