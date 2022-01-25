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
        if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x > 0f)
        {
            rb.AddForce(new Vector2(transform.position.x + dashLenght, transform.position.y));
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x < 0f)
        {
            rb.MovePosition(transform.right * (new Vector2(transform.position.x - dashLenght, transform.position.y)));
        }
    }
}

// public void MovePlayer(float _horizontalMovement)
//     {
//         Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
//         rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);