using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    Si les piques touchent le personnage alors il meurt
**/
public class Pique : MonoBehaviour
{

    public int damageToTake;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Esprit_Health>().TakeDamage(damageToTake);
        }
    }
}
