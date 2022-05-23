using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeArea : MonoBehaviour
{
   public bool seePlayer = false;

    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            seePlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            seePlayer = false;
        }
    }
}
