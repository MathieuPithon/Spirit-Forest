using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cyriaque - Des que le joueur rentre dans cette zone le bool renvoie vrai 

public class AttackArea : MonoBehaviour
{

    public bool inRange = false;



    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            inRange = true;

        }
    }
    void OnTriggerExit2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            inRange = false;

        }
    }

}
