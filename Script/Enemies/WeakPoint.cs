using System.Collections;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    public GameObject destroyObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(destroyObject);

            DataPlayerChange playerStam = collision.transform.GetComponent<DataPlayerChange>();
            playerStam.UseStam(30);
        }
    }
}
