using UnityEngine;
using System.Collections;

public class FireBallMove : MonoBehaviour
{

    private float speedBall = 15;
    private Rigidbody2D rb;
    public GameObject explosionImpact;
    public Transform explosionPoint;
    public float direction = 1;
    public SpriteRenderer fireSprite;

    private void Start()
    {
        if (!fireSprite.flipX)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        speedBall *= direction;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speedBall;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if (collision.CompareTag("Enemie"))
        {
            Instantiate(explosionImpact, explosionPoint.position, Quaternion.identity);
            Destroy(gameObject);
            StartCoroutine(Explosion());
            collision.GetComponent<Patrol_Enemy>().TakeDamage(30);
        }

        if (collision.CompareTag("Boss"))
        {
            Instantiate(explosionImpact, explosionPoint.position, Quaternion.identity);
            Destroy(gameObject);
            StartCoroutine(Explosion());
        }

        if (collision.CompareTag("Wall"))
        {
            Instantiate(explosionImpact, explosionPoint.position, Quaternion.identity);
            Destroy(gameObject);
            StartCoroutine(Explosion());
;            
            
            
        }
        
    }

    public IEnumerator Explosion()
    {
        yield return new WaitForSeconds(0.6f);
    }

    
}
