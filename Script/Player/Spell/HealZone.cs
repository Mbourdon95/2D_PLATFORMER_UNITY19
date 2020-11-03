using System.Collections;
using UnityEngine;

public class HealZone : MonoBehaviour
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
        DataPlayerChange manaBar = player.GetComponent<DataPlayerChange>();
        StartCoroutine(HealMana(manaBar));
        playerAnimator.SetBool("Spell", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
        playerAnimator.SetBool("Spell", false);
    }

    public IEnumerator HealMana(DataPlayerChange manaBar)
    {
        for (int i = 0; manaBar.GetMana() < 100; i++)
        {
            manaBar.AddMana(5);
            yield return new WaitForSeconds(1f);
            if (manaBar.GetMana() >= 100)
            {
                manaBar.ResetMana();
                Destroy(gameObject);
            }
        }  
    }
    
}
