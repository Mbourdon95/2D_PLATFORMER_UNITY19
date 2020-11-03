using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ropes_Ladders : MonoBehaviour
{


    private bool inRange;
    private Move_Player move_Player;
    public BoxCollider2D topCollider;
    private Text interact;

    void Awake()
    {
        move_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Move_Player>();
        interact = GameObject.FindGameObjectWithTag("Interact01").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && move_Player.isClimbing && Input.GetButtonDown("Climb"))
        {
            move_Player.isClimbing = false;
            topCollider.isTrigger = false;
            return;
        }
        if (inRange && Input.GetButtonDown("Climb"))
        {
            move_Player.isClimbing = true;
            topCollider.isTrigger = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interact.enabled = true;
            inRange = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        move_Player.isClimbing = false;
        topCollider.isTrigger = false;
        interact.enabled = false;
    }
}
