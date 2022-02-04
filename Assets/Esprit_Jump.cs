using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esprit_Jump : MonoBehaviour
{
    public Rigidbody2D rb;
    public void Jump()
    {
        rb.velocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime * 0.7f;
        Debug.Log("erggrg");
    }
}
