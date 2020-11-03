using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private Transform playerSpawn;
    private Animator transitSystem;

    // Start is called before the first frame update
    void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        transitSystem = GameObject.FindGameObjectWithTag("TransitSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Replace(collision));

        }
    }


    public IEnumerator Replace(Collider2D collision)
    {
        transitSystem.SetTrigger("TransitIn");
        yield return new WaitForSeconds(0.15f);
        collision.transform.position = playerSpawn.position;
        DataPlayerChange playerHealth = collision.transform.GetComponent<DataPlayerChange>();
        playerHealth.TakeDamage(10);

    }
}
