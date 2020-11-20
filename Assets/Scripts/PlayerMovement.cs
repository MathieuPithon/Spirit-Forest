
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float groundCheckRadius;
    private float horizontalMovement;
    public int jumpStamina = 50;

    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheck;
    public LayerMask collisionLayers;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D playerCollider;
    private Vector3 velocity = Vector3.zero;
    

    private void Update()
    {
        PlayerStamina playerStamina = GetComponent<PlayerStamina>();        

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;        

        if (Input.GetButtonDown("Jump") && (isGrounded == true) && (playerStamina.currentStamina >= jumpStamina)) //Jump correspond par defaut à la barre espace
        {
            isJumping = true;
            playerStamina.LoseStamina(jumpStamina);
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);             //rb.velocity.x = vitesse du personnage sur axe X
        animator.SetFloat("Speed", characterVelocity);
        MovePlayer(horizontalMovement);                                 //Si pb de déplacement remettre cette ligne dans fixedUpdate
    }

    

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
    void FixedUpdate ()//FIXED UPDATE S'UTILISE SEULEMENT POUR LES OPERATIONS DE PHYSIQUE (pas d'input ou quoi que ce soit d'autre)
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
                
    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        } else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    */
}

