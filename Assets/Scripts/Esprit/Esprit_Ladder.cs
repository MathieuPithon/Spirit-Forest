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
    public Esprit_IsGrounded isGrounded;
    public GameObject esprit;
    public Animator anim;


    private void Awake()
    {
        echelle = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            echelle = true;
        } else 
        {
            echelle = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            echelle = false;
        }
    }
    void ClimbLadder(int hautBas)
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
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
                esprit.GetComponent<Animator>().Play("PlayerLadder");
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
                rb.gravityScale = 3f;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
        if (isGrounded.isGrounded)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            esprit.GetComponent<Animator>().SetTrigger("EndClimb");
        }
        if (!echelle)
        {
            rb.gravityScale = 3f;
        }

    }
}
