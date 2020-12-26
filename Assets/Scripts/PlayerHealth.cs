using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    private float stillToHeal = 0;
    private bool healingInProgress = false;

    public float invincibilityTimeAfterHit = 2f;
    public bool isInvincible = false;
    public float invincibilityFlashDelay = 0.2f;

    public SpriteRenderer graphics;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))//test
        {
            TakeDamage(20);
        }
        if (healingInProgress)
        {
            currentHealth += 0.1f;
            stillToHeal -= 0.1f;
            healthBar.SetHealth(currentHealth);
            if (stillToHeal <= 0)
            {
                healingInProgress = false;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if(!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }
    public void Healing(float heal)
    {
        if (currentHealth + heal > 100)
        {
             heal = 100f - currentHealth;
        }
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
