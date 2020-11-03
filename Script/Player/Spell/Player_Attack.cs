using System.Collections;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    [HideInInspector]
    public Animator playerAnimator;
    [HideInInspector]
    public GameObject fireSpellRight ,fireSpellLeft, manaRegenZone ,healRegen;
    [HideInInspector]
    public Transform spawnFireBallRight, spawnFireBallLeft , spawnZone, player;
    [HideInInspector]
    public SpriteRenderer playerSprite;
    private float counterSpell = 0;
    private Rigidbody2D rb;

    // Start a SingleTone.
    public static Player_Attack instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Déjà Player_Attack dans la scène");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        DataPlayerChange Bar = player.GetComponent<DataPlayerChange>();

        // Start FireShot

        if (Input.GetButtonDown("FireShot"))
        {
            StartCoroutine(FireSpell(Bar));
        }

        // Start Spell if Player is on The ground.

        if (Move_Player.instance.onTheGround)
        {

            // Regen Mana Spell.

            if (Input.GetButtonDown("RegenMana"))
            {

                ManaRegenSpell(Bar);
            }

            // Spell Health Regen.

            if (Input.GetButtonDown("RegenHealth"))
            {
                HealRegenTouch(Bar);
            }
        }
    }

    public IEnumerator FireSpell(DataPlayerChange manaBar)
    {
        if (counterSpell == 0)
        {
            if (manaBar.GetMana() >= 30)
            {
                playerAnimator.SetBool("Spell", true);
                manaBar.UseMana(30);
                counterSpell = 1;               
                yield return new WaitForSeconds(0.7f);  
                playerAnimator.SetBool("Spell", false);
                if (!playerSprite.flipX)
                {
                    Instantiate(fireSpellRight, spawnFireBallRight.position, spawnFireBallRight.rotation);
                }
                else
                {
                    Instantiate(fireSpellLeft, spawnFireBallLeft.position, spawnFireBallLeft.rotation);
                }
                yield return new WaitForSeconds(3f);
                counterSpell = 0;
            }
        }
    }

    public void HealRegenTouch(DataPlayerChange manaBar)
    {
        if (counterSpell == 0)
        {
            if ((manaBar.GetMana() > 49) && (manaBar.GetHealth() < 100))
            {
                counterSpell = 1;
                Instantiate(healRegen, spawnZone.position, spawnZone.rotation);
                StartCoroutine(Time());
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    public void ManaRegenSpell(DataPlayerChange manaBar)
    {
        if (counterSpell == 0)
        {
            if (manaBar.GetMana() < 100)
            {
                counterSpell = 1;
                Instantiate(manaRegenZone, spawnZone.position, spawnZone.rotation);
                StartCoroutine(Time());
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    public IEnumerator Time()
    {
        yield return new WaitForSeconds(2f);
        counterSpell = 0;
    }
}
