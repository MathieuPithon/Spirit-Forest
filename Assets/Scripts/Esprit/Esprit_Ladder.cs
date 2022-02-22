using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esprit_Ladder : MonoBehaviour
{
    private float verticalMovement;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public float moveSpeed;
    public bool echelle = false;



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ladder"))
        {
            echelle = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ladder"))
        {
            echelle = false;
        }
    }
    void ClimbLadder(int hautBas)
    {
        rb.gravityScale = 0.0f;
        verticalMovement = hautBas * Time.fixedDeltaTime * moveSpeed;
        Vector3 wantedVelocity = new Vector2(rb.velocity.x, verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, wantedVelocity, ref velocity, .05f);
    }
    void Update()
    {
        if (echelle)
        {
            if (Input.GetKey("z"))
            {
                ClimbLadder(1);
            }
            if (Input.GetKeyUp("z"))
            {
                rb.velocity = Vector3.zero;
            }
            if (Input.GetKey("s"))
            {
                ClimbLadder(-1);
            }
            if (Input.GetKeyUp("s"))
            {
                rb.velocity = Vector3.zero;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.gravityScale = 2f;
            }
        }

    }
}
