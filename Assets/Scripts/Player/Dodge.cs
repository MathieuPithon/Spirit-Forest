using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    public float dashLenght;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x > 0f)
        {
            transform.position = new Vector2(transform.position.x + dashLenght, transform.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x < 0f)
        {
            transform.position = new Vector2(transform.position.x - dashLenght, transform.position.y);
        }
    }
}
