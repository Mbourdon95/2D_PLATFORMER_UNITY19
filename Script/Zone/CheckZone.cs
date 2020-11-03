using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckZone : MonoBehaviour
{
    private Transform playerSpawn;
    private Animator flag;

    // Start is called before the first frame update
    void Start()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        flag = GameObject.FindGameObjectWithTag("CheckPoints").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            flag.SetTrigger("Check");
            playerSpawn.position = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

}
