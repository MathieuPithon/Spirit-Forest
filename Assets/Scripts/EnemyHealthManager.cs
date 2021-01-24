using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{    
    public int maxHealth;
    public int currentHealth;
    public int xpEarned = 2;

    public PlayerXp xp;
    void Start()
    {
        currentHealth = maxHealth;
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
    }
    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
