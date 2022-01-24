using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
    Des que le joueur rentre dans cette zone le bool renvoie vrai --> l'ennemi marche en arrière
**/


public class EnemyLance_WalkBackward : MonoBehaviour
{

    //De base la valeur est false car on ne veut pas que l'ennemi marche en arrière constamment
    public bool needBack = false;

    //Si le joueur est dans la zone (hitbox) alors l'ennemi recule
    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            needBack = true;

        }
    }

    //Si le joueur sort de la hitbox alors la valeur passe false et donc l'ennemi arrête de reculer. 
    void OnTriggerExit2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            needBack = false;

        }
    }
}

