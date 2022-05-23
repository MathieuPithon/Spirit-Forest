using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platfromArea : MonoBehaviour
{
    public bool onPlatfrom = false;

    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            onPlatfrom = true;
        }
    }
    void OnTriggerExit2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            onPlatfrom = false;
        }
    }
}
