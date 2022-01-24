using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cyriaque - Des que le joueur rentre dans cette zone le bool renvoie vrai 
public class EnemyLance_Agro : MonoBehaviour
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

