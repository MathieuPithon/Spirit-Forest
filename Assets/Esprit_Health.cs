using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cyriaque - dans 'public Healthbar' il faut mettre la health bar qui est dans canvas 
// si le joueur rentre en collision avec qql chose du layer Enemy alors il prend des dmg (fonction TakeDamage)
//https://www.youtube.com/watch?v=BLfNP4Sc_iA
public class Esprit_Health : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
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
