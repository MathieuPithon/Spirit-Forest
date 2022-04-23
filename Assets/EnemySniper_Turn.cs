using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper_Turn : MonoBehaviour
{

    public bool needTurn;
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
