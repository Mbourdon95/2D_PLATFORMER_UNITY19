using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInMenuUp : MonoBehaviour
{
    private float dirX, speed = 250f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    private void Start()
    {
        if (!sr.flipX)
        {
            dirX = -1.4f;
        }
        else
        {
            dirX = 1.4f;
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
}
