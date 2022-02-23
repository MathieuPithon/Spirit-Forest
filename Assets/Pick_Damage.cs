using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Damage : MonoBehaviour
{
    public Esprit_Health health;

    void OnCollision2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            health.TakeDamage(50);
            Debug.Log("etst");
        }
    }
}
