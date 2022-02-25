using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper_CaCAttack : MonoBehaviour
{
    public bool inRangeCaC = false;

    void OnTriggerEnter2D(Collider2D Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            inRangeCaC = true;
        }
    }

    void OnTriggerExit2D(Collider2D Player)
    {
          if(Player.gameObject.tag == "Player")
        {
            inRangeCaC = false;
        }
    }
}