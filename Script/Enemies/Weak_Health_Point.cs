using UnityEngine;

public class Weak_Health_Point : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Boss_Health boss_Health = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss_Health>();
            boss_Health.TakeDamage(40);

            DataPlayerChange playerStam = collision.transform.GetComponent<DataPlayerChange>();
            playerStam.UseStam(30);
        }
    }
}
