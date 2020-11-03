using System.Collections;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{

    private int maxHealth = 100;
    public float currentHealth;
    public Animator bossAnimator;

    public GameObject destroyBoss;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int _damage)
    {
        
        currentHealth -= _damage;

        if (currentHealth > 0)
        {
            bossAnimator.SetTrigger("Hurt");
        }
        

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        bossAnimator.SetTrigger("Death");
        StartCoroutine(Death());    
        
    }

    private IEnumerator Death()
    {  
        yield return new WaitForSeconds(0.8f);
        Destroy(destroyBoss);
    }
}
