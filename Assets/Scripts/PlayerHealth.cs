using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private float currentHealth;
    public float CurrentHealth { get { return currentHealth; }
                                 set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }
    public float stillToHeal;
    public float stillToDmg;
    private bool healingInProgress = false;
    private bool damageInProgress = false;
    
    public float invincibilityTimeAfterHit = 2f;
    public bool isInvincible = false;
    public float invincibilityFlashDelay = 0.2f;
    public PlayerStamina stamina;
    public PlayerCombat combat;
    
    public SpriteRenderer graphics;
    public HealthBar healthBar;
    void Start()
    {
        CurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {//test
            TakeDamage(19, false);
            Debug.Log("take damage");
        }
        if (healingInProgress)
        {
            CurrentHealth += 0.1f;
            stillToHeal -= 0.1f;
            healthBar.SetHealth(CurrentHealth);
            if (stillToHeal < 0)
            {
                CurrentHealth += 0.01f;
                healingInProgress = false;
            }                
        }
        if (damageInProgress)
        {
            CurrentHealth -= 0.2f;
            stillToDmg -= 0.2f;
            healthBar.SetHealth(CurrentHealth);
            if (stillToDmg < 0)
            {
                CurrentHealth -= 0.01f;
                damageInProgress = false;
            }                
        }
        
    }
    public void TakeDamage(int damage, bool attackPlacement)
    {
        if (!isInvincible)
        {
            if (combat.placement == attackPlacement)
            {
                if (combat.paradeActive == true)
                {
                }
                stamina.LoseStamina(damage * 3);
            }
            else
            {
                stillToDmg = damage;
                damageInProgress = true;
                isInvincible = true;
                StartCoroutine(InvincibilityFlash());
                StartCoroutine(HandleInvincibilityDelay());
            }
        }

    }
    public void Healing(float heal)
    {
        stillToHeal = heal;
        healingInProgress = true;
    }
    public IEnumerator InvincibilityFlash() //IEnumerator créé une coroutine
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay); //pour ajouter un délai on utilise souvent yield
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }
    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
    
}
