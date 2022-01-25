using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dash : MonoBehaviour
{
    public float dashLenght;
    public float dashSpeed;
    public Rigidbody2D rb;
    void Start()
    {

    }

    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        if (rb.velocity.x > 7)
        {
            rb.GetComponent<Rigidbody2D>().gravityScale = 0f;
            Debug.Log("1");
        }
        else
        {
            rb.GetComponent<Rigidbody2D>().gravityScale = 1f;
            Debug.Log("0");
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x + dashLenght, rb.velocity.y);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x < 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x - dashLenght, rb.velocity.y);
        }
    }


}

// public void MovePlayer(float _horizontalMovement)
//     {
//         Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
//         rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);