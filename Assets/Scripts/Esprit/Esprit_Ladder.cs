using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esprit_Ladder : MonoBehaviour
{
    private float verticalMovement;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public float moveSpeed;




    void ClimbLadder()
    {
        rb.gravityScale = 0.0f;
        verticalMovement = Time.fixedDeltaTime * moveSpeed;
        Vector3 wantedVelocity = new Vector2(rb.velocity.x, verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, wantedVelocity, ref velocity, .05f);
    }
    void Update()
    {
        if (Input.GetKey("z"))
        {
            ClimbLadder();
        }
        if (Input.GetKeyUp("z"))
        {
            rb.velocity = Vector3.zero;
        }

    }
}
