using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    //PlayerHealth health;
    public PlayerHealth health;
    public int potionValue = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //health = GameObject.Find("Player").GetComponent<PlayerHealth>();
            health.Healing(potionValue);
            Destroy(gameObject);
        }
    }
   
}
