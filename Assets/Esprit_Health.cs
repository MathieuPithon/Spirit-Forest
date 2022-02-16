using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cyriaque - dans 'public Healthbar' il faut mettre la health bar qui est dans canvas 
//https://www.youtube.com/watch?v=BLfNP4Sc_iA
public class Esprit_Health : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;
    public CapsuleCollider2D hitbox ;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (hitbox )
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}
