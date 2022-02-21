using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esprit_IsGrounded : MonoBehaviour
{
    [HideInInspector]
    public bool isGrounded;
    public Transform groundCheck;
    private float groundCheckRadius = 0.63f;
    public LayerMask collisionGroundLayers;

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionGroundLayers);
    }

}
