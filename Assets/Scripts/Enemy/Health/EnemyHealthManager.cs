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
    public int xpEarned = 4;

    public EnemyHealthBar healthBar;
    public PlayerXp xp;
    public AudioSource deathSound;
    public GameObject Samourai;
    void Start()
    {
        SetMaxHealth();

    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            deathSound.Play();
            //jouer animation de mort
            Samourai.GetComponent<Animator>().Play("SamouraiDie");
            GetComponent<EnemyLance_HitBoxLance>().enabled = false;
            Samourai.SetActive(false);
            Destroy(Samourai);
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
