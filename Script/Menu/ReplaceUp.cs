using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceUp : MonoBehaviour
{
    public GameObject respawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = respawn.transform.position;
        }

        if (collision.CompareTag("Enemie"))
        {
            collision.transform.position = respawn.transform.position;
        }
    }
}
