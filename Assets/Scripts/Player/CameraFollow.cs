
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffSet;
    private Vector3 posOffSet; // ??? le Y c'est posOffSetGrounded -1 (la variable d'en dessous)
    public Vector3 posOffSetGrounded;
    public PlayerMovement movement;
    private Vector3 velocity = Vector3.zero;
    public Rigidbody rb;

    void Update()
    {
        directionCameraDeplacement(velocity.x);

        if (movement.isGrounded)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffSetGrounded, ref velocity, timeOffSet);
        }
        else transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffSet, ref velocity, timeOffSet);

    }

    void directionCameraDeplacement(float velocity)
    {

        rb = player.GetComponent<RigidBody>();
        print(rb.velocity);

        if(velocity > 1f)
        {
            posOffSet=new Vector3(2f, 0f, -10f);
            posOffSetGrounded=new Vector3(2f, 0f, -10f);
        }
        else if (velocity<-1f)
        {
            posOffSet=new Vector3(-2f, 0f, -10f);
            posOffSetGrounded=new Vector3(-2f, 0f, -10f);
        }
        else 
        {
            posOffSet=new Vector3(0f, 0f, -10f);
            posOffSetGrounded=new Vector3(0f, 0f, -10f);
        }
    }
}
