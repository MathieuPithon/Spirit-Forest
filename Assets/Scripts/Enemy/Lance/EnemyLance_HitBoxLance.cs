using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    Si la lance touche le personnage alors il prends des dégats
**/
public class EnemyLance_HitBoxLance : MonoBehaviour
{

    public int damageToTake;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Esprit_Health>().TakeDamage(20);
        }
    }
}
