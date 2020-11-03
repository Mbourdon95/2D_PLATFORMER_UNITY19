using UnityEngine;

public class Patrol_Enemy : MonoBehaviour
{
    // Vitesse Ennemie
    public float moveSpeed;
    // Génération D'un Tableau pour avoir les points de déplacement.
    public Transform[] checkPoints;

    //On génère une cible et son int pour débloquer l'index du tableau
    public Transform theTarget;
    public int toDest;
    public SpriteRenderer enemiesSprite;

    private int currentHealth = 20;

    public GameObject objectDestroy;
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
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime,Space.World);
        if (Vector3.Distance(transform.position,theTarget.position)< 0.3f)
        {
            //On change le point d'arrivé grâce a toDest
            toDest = (toDest + 1) % checkPoints.Length;
            theTarget = checkPoints[toDest];
            //On prend son contraire comme il s'agit d'un booléen au moment du change de waypoint.
            enemiesSprite.flipX = !enemiesSprite.flipX;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            toDest = (toDest + 1) % checkPoints.Length ;
            theTarget = checkPoints[toDest];
            enemiesSprite.flipX = !enemiesSprite.flipX;
            DataPlayerChange playerHealth = collision.transform.GetComponent<DataPlayerChange>();
            playerHealth.TakeDamage(30);           
        }
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        if (currentHealth < 1)
        {
            Destroy(objectDestroy);
        }
    }
}
