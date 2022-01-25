using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    public float dashLenght;
     public GameObject theplayer;
        public PlayerCombat combat;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x > 0f)
        {
            transform.position = new Vector2(transform.position.x + dashLenght, transform.position.y);
              theplayer.GetComponent<Animator>().Play("PlayerDash");
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x < 0f)
        {
            transform.position = new Vector2(transform.position.x - dashLenght, transform.position.y);
              theplayer.GetComponent<Animator>().Play("PlayerDash");
        }
    }
}
