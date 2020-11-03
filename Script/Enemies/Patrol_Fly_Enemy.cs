using System.Collections;
using UnityEngine;

public class Patrol_Fly_Enemy : MonoBehaviour
{
    private float speed = 250f, circleRadius = 0.2f, attackRadius = 4f, attackSpeed = 3f;
    private float distanceFromPlayer;
    private Transform player;
    private SpriteRenderer enemiesSprite;
    private SpriteRenderer playerSprite;


    private Rigidbody2D EnemyRB;
    public GameObject rightCheck, roofCheck, groundCheck;
    public LayerMask groundLayer;
    private bool facingRight = true, groundTouch, roofTouch, righttouch;
    private float dirX = 1, dirY = 0.4f;

    public int currentHealth = 40;

    public GameObject objectDestroy;

    void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        enemiesSprite = GameObject.FindGameObjectWithTag("Enemie").GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        distanceFromPlayer = Vector2.Distance(player.position,transform.position);
        if (distanceFromPlayer < attackRadius)
        {
            //if (player.position.x  > transform.position.x)
            //{
            //    transform.Rotate(new Vector3(0, -180, 0));
            //}
            //if (player.position.x < transform.position.x)
            //{
            //    transform.Rotate(new Vector3(0, 180, 0));
            //}
            transform.position = Vector2.MoveTowards(transform.position,player.position, attackSpeed * Time.deltaTime);
        }
        else
        {
            EnemyRB.velocity = new Vector2(dirX, dirY) * speed * Time.deltaTime;
            HitDetection();
        }
        


    }

    void HitDetection()
    {
        righttouch = Physics2D.OverlapCircle(rightCheck.transform.position, circleRadius, groundLayer);
        roofTouch = Physics2D.OverlapCircle(roofCheck.transform.position, circleRadius, groundLayer);
        groundTouch = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadius, groundLayer);
        HitLogic();
    }

    void HitLogic()
    {
        if (righttouch && facingRight)
        {
            Flip();
        }
        else if (righttouch && !facingRight)
        {
            Flip();
        }
        if (roofTouch)
        {
            dirY = -0.4f;
        }
        else if (groundTouch)
        {
            dirY = 0.4f;
        }


    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
        dirX = -dirX;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            HitDetection();
            StartCoroutine(Change());
            DataPlayerChange playerHealth = collision.transform.GetComponent<DataPlayerChange>();
            playerHealth.TakeDamage(30);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(rightCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(roofCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(groundCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        if (currentHealth < 1)
        {
            Destroy(objectDestroy);
        }
    }

    public IEnumerator Change()
    {
        attackRadius = 0;
        yield return new WaitForSeconds(3f);
        attackRadius = 4f;
    }

}
