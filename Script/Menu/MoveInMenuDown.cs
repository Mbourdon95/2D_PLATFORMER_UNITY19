using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInMenuDown : MonoBehaviour
{
    private float dirX=1.5f, speed = 250f, detect = 4f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

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
        if (collision.CompareTag("MainMenu"))
        {
            sr.flipX = !sr.flipX;
            dirX *= -1;
        }
    }
}
