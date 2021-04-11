using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goBack : MonoBehaviour
{

    public bool needBack = false;



    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            needBack = true;
            
        }
    }
    void OnTriggerExit2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            needBack = false;
            
        }
    }
}
    
