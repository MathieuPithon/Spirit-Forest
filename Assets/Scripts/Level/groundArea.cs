using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundArea : MonoBehaviour
{
    public bool isGrounded = false;

    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            isGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            isGrounded = false;
        }
    }
}
