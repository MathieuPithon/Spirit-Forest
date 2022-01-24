
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffSet;
    private Vector3 posOffSet = new Vector3(0f, 2f, -10f); // ??? le Y c'est posOffSetGrounded -1 (la variable d'en dessous)
    public Vector3 posOffSetGrounded;
    public PlayerMovement movement;


    private Vector3 velocity;
    void Update()
    {

        if (movement.isGrounded)
        {
            
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffSetGrounded , ref velocity, timeOffSet);
        }
        else transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffSet, ref velocity, timeOffSet);

        
    }
}
