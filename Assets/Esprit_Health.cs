using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cyriaque - dans 'public Healthbar' il faut mettre la health bar qui est dans canvas 
// si le joueur rentre en collision avec qql chose du layer Enemy alors 
// colide = true et il prend des dmgs , quand il arrete de toucher un ennemi colide = false 
// quand il se fait toucher une coroutine de 2 s start et pendant ce temps il est invinsible 
public class Esprit_Health : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;
    private bool invicibility = false;
    private bool colide = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (invicibility == false)
        {
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                colide = true;
            }

        }
    }

    void onCollisionExit2D(Collision2D collision)
    {
        colide = false;
    }

    void Update()
    {
        if (colide && !invicibility)
        {
            TakeDamage(20);
            StartCoroutine(Delay());
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    IEnumerator Delay()
    {
        invicibility = true;
        Debug.Log("true");
        yield return new WaitForSeconds(2f);
        invicibility = false;
    }


}
