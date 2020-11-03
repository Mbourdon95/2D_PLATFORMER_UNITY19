using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : MonoBehaviour
{
    private Transform player;
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            DataPlayerChange manaHealthBar = player.GetComponent<DataPlayerChange>();
            playerAnimator.SetBool("Spell", true);
            manaHealthBar.UseMana(50);
            manaHealthBar.AddHealth(30);

            if (manaHealthBar.GetHealth() > 100)
            {
                manaHealthBar.ResetHealth();
            }
            playerAnimator.SetBool("Spell", false);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
        
    }
}
