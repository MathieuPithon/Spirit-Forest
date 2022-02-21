using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Cyriaque - Gere les mouvement droite / gauche de l'esprit

public class Esprit_Mouvement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    private float horizontalMovement;
    private Vector3 velocity = Vector3.zero;
    // public static espritMovement instance;
    public Animator animator;


    public void Mouvement()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * moveSpeed;
        Vector3 wantedVelocity = new Vector2(horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, wantedVelocity, ref velocity, .05f);
        
    }

 
  
    void Update()
    {
        Mouvement();

        float characterVelocity = Mathf.Abs(rb.velocity.x);  
        animator.SetFloat("Speed",characterVelocity);

    }

}
