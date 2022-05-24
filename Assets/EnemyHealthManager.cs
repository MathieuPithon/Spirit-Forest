using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
    Initialise les variables qui sont mises dans la barre de vie, ainsi que l'évènement quand HP = 0
**/
public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public OursHealth healthBar;
    public AudioSource deathSound;
    public GameObject Samourai;
    public Animator animator;
    void Start()
    {
        SetMaxHealth();

    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            deathSound.Play();
            animator.SetBool("die", true);
            //jouer animation de mort
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
        healthBar.SetMaxHealth(maxHealth);
    }
}
