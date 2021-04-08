
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffSet;
    private Vector3 posOffSet = new Vector3(0f, 0f, -10f);
    public Vector3 posOffSetGrounded = new Vector3(0f, 1f, -10f); //Pas toucher svp
    public PlayerMovement movement;
    

    private Vector3 velocity;
    void Update()
    {
         
        
        if (movement.isGrounded)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffSetGrounded, ref velocity, timeOffSet);
        } else transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffSet, ref velocity, timeOffSet);
        
    }
}
