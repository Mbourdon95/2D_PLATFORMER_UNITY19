using System.Collections;
using UnityEngine;

public class Move_Player : MonoBehaviour
{
    private float moveSpeed = 350,climbSpeed = 175, jumpPower = 455, timeSpend = 0f, footradius = 0.3f, xMovement,yMovement;
    [HideInInspector]
    public bool inTheAir, onTheGround, onHit, onTaunt;
    [HideInInspector]
    public bool isClimbing;
    [HideInInspector]
    public CapsuleCollider2D playerCollider;


    [HideInInspector]
    public Transform checkFoot;
    public LayerMask CollisionLayer;

    [HideInInspector]
    public Animator bodyAnimator;
    [HideInInspector]
    public SpriteRenderer bodySprite;
    [HideInInspector]
    public Rigidbody2D personnage;
    private Vector3 theSpeed = Vector3.zero;


    public static Move_Player instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Déjà Move_Player dans la scène");
            return;
        }
        instance = this;
    }

    void Update()
    {
        // On récupére à chaque Frame la vitesse en x et y.


        xMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        yMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;


        if (Input.GetButtonDown("Jump") && onTheGround && !isClimbing)
        {
            inTheAir = true;
        }

        Flip_Face(personnage.velocity.x);

        // Lors du déplacment à gauche, le personnage possède une vitesse négative, on prend donc la valeur absolue de sa vitesse.
        float move_Player_X = Mathf.Abs(personnage.velocity.x);
        float move_Player_Y = Mathf.Abs(personnage.velocity.y);
        bodyAnimator.SetFloat("SpeedX", move_Player_X);
        bodyAnimator.SetFloat("SpeedY", personnage.velocity.y);
        bodyAnimator.SetBool("onGround", onTheGround);
        bodyAnimator.SetBool("isClimbing", isClimbing);
        
    }
    
    private void FixedUpdate()
    {
        onTheGround = Physics2D.OverlapCircle(checkFoot.position, footradius, CollisionLayer);
        Set_Move(xMovement,yMovement);
    }

    void Set_Move(float _xMovement, float _yMovement)
    {
        if (!isClimbing)
        {
            Vector3 target = new Vector2(_xMovement, personnage.velocity.y);
            personnage.velocity = Vector3.SmoothDamp(personnage.velocity, target, ref theSpeed, .05f);

            if (inTheAir)
            {
                personnage.AddForce(new Vector2(0f, jumpPower));
                inTheAir = false;
            }
        }
        else
        {
            Vector3 target = new Vector2(0f, _yMovement);
            personnage.velocity = Vector3.SmoothDamp(personnage.velocity, target, ref theSpeed, .05f);
        }
        
    }

    // On test si la vitesse est négative et positive et on tourne le personnage dans le sens du mouvement.
    void Flip_Face(float _xMovement)
    {
        if (_xMovement > .01f)
        {
            bodySprite.flipX = false;
        }
        else if(_xMovement < -.01f)
        {
            bodySprite.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkFoot.position, footradius);

    }
}
