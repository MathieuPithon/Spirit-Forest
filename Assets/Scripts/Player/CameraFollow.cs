
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public const float V = 0.3f;
    public GameObject player;
    public float timeOffSet;
    private Vector3 posOffSet; // ??? le Y c'est posOffSetGrounded -1 (la variable d'en dessous)
    public Vector3 posOffSetGrounded;
    public PlayerMovement movement;
    private Vector3 velocity = Vector3.zero;

    public Rigidbody2D rb;

    void Update()
    {
        directionCameraDeplacement(rb.velocity.x,rb.velocity.y);

        if (movement.isGrounded)
        {
            
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffSetGrounded , ref velocity, timeOffSet);
        }
        else transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffSet, ref velocity, timeOffSet);

        
    }
    void directionCameraDeplacement(float velocityX, float velocityY)
    {
        //si le personnage va en haut à droite
        if(velocityX > -V && velocityY >V)
        {
            posOffSet=new Vector3(1f, 0.5f, -10f);
            posOffSetGrounded=new Vector3(1f, 0.5f, -10f);
            
        }
        //si le personnage va en haut à gauche
        else if (velocityX < -V && velocityY >V )
        {
            posOffSet=new Vector3(-1f, 0.5f, -10f);d
            posOffSetGrounded=new Vector3(-1f, 0.5f, -10f);
        }
        //si le personnage va en bas à droite
        else if (velocityX >V && velocityY <-V)
        {
            posOffSet=new Vector3(1f, -0.5f, -10f);
            posOffSetGrounded=new Vector3(-1f, -0.5f, -10f);
        }
        //si le personnage se va en bas à gauche
        else if (velocityX < -V && velocityY <-V)
        {
            posOffSet=new Vector3(-1f, -0.5f, -10f);
            posOffSetGrounded=new Vector3(-1f, -0.5f, -10f);
        } 
        //si le personnage se déplace sur la droite sans sauter
        else if(velocityX > V )
        {
            posOffSet=new Vector3(2f, 0f, -10f);
            posOffSetGrounded=new Vector3(2f, 0f, -10f);
        }
        //si le personnage ne bouge pas
        else 
        {
            posOffSet=new Vector3(0f, 0f, -10f);
            posOffSetGrounded=new Vector3(0f, 0f, -10f);
        }
        

       
    }
}
