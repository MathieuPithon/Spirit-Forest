using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{    
    public int maxHealth;
    public int currentHealth;
    public int xpEarned = 2;

    public EnemyHealthBar healthBar;
    public PlayerXp xp;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
       if (currentHealth <= 0)
        {
            xp.XpGain(xpEarned);
            Destroy(gameObject);
        }
    }    
    public void HurtEnemy(int damageTaken)
    {
        //animation de l'ennemi qui subit des dégats
        currentHealth -= damageTaken;
        healthBar.SetHealth(currentHealth);
    }
    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
