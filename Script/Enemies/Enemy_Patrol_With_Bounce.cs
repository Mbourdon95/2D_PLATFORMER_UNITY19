using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol_With_Bounce : MonoBehaviour
{
    // Vitesse Ennemie
    public float moveSpeed;
    // Génération D'un Tableau pour avoir les points de déplacement.
    public Transform[] checkPoints;

    //On génère une cible et son int pour débloquer l'index du tableau
    public Transform theTarget;
    public int toDest;


    public Animator enemyAnimator;
    public SpriteRenderer enemySprite;
    // Start is called before the first frame update



    void Start()
    {
        //Initialise le premier point.
        theTarget = checkPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        // normalized set le vecteur à une taille fixe.
        Vector3 direction = theTarget.position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, theTarget.position) < 0.3f)
        {
            //On change le point d'arrivé grâce a toDest
            toDest = (toDest + 1) % checkPoints.Length;
            theTarget = checkPoints[toDest];
            //On prend son contraire comme il s'agit d'un booléen au moment du change de waypoint.
            enemySprite.flipX = !enemySprite.flipX;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            toDest = (toDest + 1) % checkPoints.Length;
            theTarget = checkPoints[toDest];
            enemySprite.flipX = !enemySprite.flipX;
        }
    }
}
