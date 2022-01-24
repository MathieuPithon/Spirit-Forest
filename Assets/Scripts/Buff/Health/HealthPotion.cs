using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
    Augmente les pdv du personnage
**/
public class HealthPotion : MonoBehaviour
{
    //PlayerHealth health;
    public PlayerHealth health;
    public int potionValue = 30;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //si le joueur est sur la potion alors il est soigné de la valeur de la potion soit 30 pdv
        if (collision.CompareTag("Player"))
        {
            //health = GameObject.Find("Player").GetComponent<PlayerHealth>();
            health.Healing(potionValue);
            Destroy(gameObject);
        }
    }
   
}
