using System.Collections;
using UnityEngine;

public class DataPlayerChange : MonoBehaviour
{
    private int maxHealth = 100, maxStam = 100, maxMana = 100, currentHealth, currentStam, currentMana;

    [HideInInspector]
    public StamBar stamBar;
    [HideInInspector]
    public HealthBar healthBar;
    [HideInInspector]
    public ManaBar manaBar;

    private bool onHit = false;
    [HideInInspector]
    public SpriteRenderer player;
    private float delay = 0.15f;
    [HideInInspector]
    public Animator playerAnimator;


    public static DataPlayerChange instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Déjà DataPlayer dans la scène");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentStam = maxStam;
        stamBar.SetMaxStam(maxStam);

        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }

    // Update is called once per frame
    private void Update()
    {
        playerAnimator.SetBool("onHit", onHit);
        if (currentStam != maxStam)
        {
            StartCoroutine(RegenStam());
        }
    }

    public void TakeDamage(int _damage)
    {
        if (!onHit)
        {
            currentHealth -= _damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
                return;
            }
            onHit = true;
            playerAnimator.SetBool("onHit", onHit);
            StartCoroutine(IsOnHit());
            StartCoroutine(StopOnHit());
        }
        
    }

    public void Die()
    {
        Move_Player.instance.enabled = false;
        Player_Attack.instance.enabled = false;
        Move_Player.instance.bodyAnimator.SetTrigger("Death");
        Move_Player.instance.personnage.bodyType = RigidbodyType2D.Kinematic;
        Move_Player.instance.personnage.velocity = Vector3.zero;
        Move_Player.instance.playerCollider.enabled = false;
        GameOverManagement.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        Move_Player.instance.enabled = true;
        Player_Attack.instance.enabled = true;
        Move_Player.instance.bodyAnimator.SetTrigger("Respawn");
        Move_Player.instance.personnage.bodyType = RigidbodyType2D.Dynamic;
        Move_Player.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        currentMana = maxMana;
        manaBar.SetMana(currentMana);

    }
    public void UseStam(int _stam)
    {
        currentStam -= _stam;
        stamBar.SetStam(currentStam);
    }

    public void UseMana(int _mana)
    {
        currentMana -= _mana;
        manaBar.SetMana(currentMana);
    }


    public void AddMana(int _mana)
    {
        currentMana += _mana;
        manaBar.SetMana(currentMana);
    }

    public void ResetMana()
    {
        currentMana = maxMana;
        manaBar.SetMana(currentMana);
    }

    public int GetMana()
    {
        return currentMana;
    }

    public void AddHealth(int _health)
    {
        currentHealth += _health;
        healthBar.SetHealth(currentHealth);
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
    public int GetHealth()
    {
        return currentHealth;
    }

    public IEnumerator IsOnHit()
    {
        
        while (onHit)
        {
            player.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(delay);
            player.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(delay);

        }
    }
    public IEnumerator StopOnHit()
    {
        yield return new WaitForSeconds(2f);
        onHit = false;
        playerAnimator.SetBool("onHit", onHit);
    }

    public IEnumerator RegenStam()
    {
        while (!onHit)
        {
            yield return new WaitForSeconds(10f);
            stamBar.SetMaxStam(maxStam);
        }        
    }
}
