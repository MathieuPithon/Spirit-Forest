using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitCharge : MonoBehaviour
{
    public bool hited = false;

    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            hited = true;
        }
    }
    void OnTriggerExit2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            hited = false;
        }
    }
}
