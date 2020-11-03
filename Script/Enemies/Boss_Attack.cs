using System.Collections;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    private float attackRadius = 0f, detect = 4.5f, distanceFromPlayer;
    private int bossDamage = 30;


    private Transform player;
    public Transform axe;

    private SpriteRenderer bossSprite;
    private SpriteRenderer playerSprite;


    public Animator bossAnimator;
    
    public LayerMask playerLayer;
    
    private bool firstAttack = false, secondAttack = false, hit = false;


    void Start()
    {
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        bossSprite = GameObject.FindGameObjectWithTag("Boss").GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {

        distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        DetectPlayer();
        Attack();
    }

    private void DetectPlayer()
    {

        // Si le joueur est en face du Minotaure, il utilise sa première attaque
        // S'il est dos à lui, il utilise sa deuxième attaque.

        if (distanceFromPlayer < detect)
        {
            if (bossSprite.flipX == !playerSprite.flipX)
            {
                firstAttack = true;
                StartCoroutine(Change());
            }

            if (bossSprite.flipX == playerSprite.flipX)
            {
                secondAttack = true;
                StartCoroutine(Change());
            }
        }
        else
        {
            firstAttack = false;
            secondAttack = false;
        }
    }


    private void Attack()
    {
        hit = true;
        // On ajoute les animations, elle se lance si first est 'true' ou bien si second est 'true'.
        bossAnimator.SetBool("Attack1", firstAttack);
        bossAnimator.SetBool("Attack2", secondAttack);

        // On instancie un tableau qui récupère tout les Collider qui rentre dans la hache au moment de l'attaque. 
        Collider2D[] player_Hits = Physics2D.OverlapCircleAll(axe.position, attackRadius, playerLayer);

        // Pour chaque item (uniquement player ici (on prépare la possibilité de toucher deux joueurs à l'avenir))
        // on récupère sa santé et on la décrémente de la puissance du Minotaure.

        foreach (Collider2D item in player_Hits)
        {
            DataPlayerChange playerHealth = item.transform.GetComponent<DataPlayerChange>();
            playerHealth.TakeDamage(bossDamage);
        }

        

    }

    private void OnDrawGizmosSelected()
    {
        // On colorie les Sphères en Bleu Foncé.
        // La Première nous donne la sphère d'attaque de la hache
        // La Deuxième nous donne la sphère de detection du Minotaure.


        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(axe.position, attackRadius);
        Gizmos.DrawWireSphere(transform.position, detect);
    }

    public IEnumerator Change()
    {

        // On augmente La distance d'attaque lors de l'attaque.
        attackRadius = 4f;

        // On supprime la distance de détection pour éviter les attaques multiples. 
        detect = 0;
        yield return new WaitForSeconds(1f);

        // On remet les valeurs par défaut. 
        attackRadius = 0f;
        yield return new WaitForSeconds(2f);
        detect = 4.5f;
    }
}
