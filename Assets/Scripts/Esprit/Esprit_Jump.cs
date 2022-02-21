using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cyriaque - Si espace est appuyé une impulsion est ajouter au rigide body 
//(je crois c'est pas possible de le mettre en public donc faut changer dans le code la hauteur du saut)
public class Esprit_Jump : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public Esprit_Stamina Stamina;
    public Esprit_IsGrounded IsGrounded;
    public Animator animator;
    public void Jump()
    {
        rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded.isGrounded)
        {
            Jump();
            Stamina.ReduceStamina(10);    
            animator.SetBool("Jump", true);        
        
        }else if(IsGrounded.isGrounded)
        {
            animator.SetBool("Jump", false);
        }

    }
}

