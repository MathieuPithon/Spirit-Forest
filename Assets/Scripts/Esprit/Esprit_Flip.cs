using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Cyriaque - fait bouger le sprite du joueur dans le sens de la velocité
public class Esprit_Flip : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    void Flip(float velocity)
    {
        if (velocity > 0.1f)
        {
            spriteRenderer.transform.localScale = new Vector3(0.21f, 0.17f, 1);
        }
        else if (velocity < -0.1f)
        {
            spriteRenderer.transform.localScale = new Vector3(-0.21f, 0.17f, 1);
        }
    }
    void Update()
    {
        Flip(rb.velocity.x);
    }
}
