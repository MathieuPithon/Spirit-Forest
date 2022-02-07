using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esprit_Jump : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public void Jump()
    {
        rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    }
}

