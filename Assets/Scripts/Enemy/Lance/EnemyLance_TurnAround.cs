using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
    Cyriaque - Dès que le joueur rentre dans cette zone le bool renvoie vrai 
    Permet à l'ennemi de se retourner en fonction de la postion du joueur
**/ 

public class EnemyLance_TurnAround : MonoBehaviour
{

    public bool needTurn = false;



    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            needTurn = true;

        }
    }
    void OnTriggerExit2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            needTurn = false;

        }
    }
}

