using System.Collections;
using UnityEngine;

public class BetterJumps : MonoBehaviour // Voir peut être si il est possible d'intégrer ce script dans le script PlayerMovement
{                                       // Là où le jump a été codé
    public float fallMultiplier = 2.5f;
    public float jumpHight = 10f;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime * jumpHight;
        }
    }
}
