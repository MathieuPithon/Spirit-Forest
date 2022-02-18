using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cyriaque - Fait dasher le perso vers la droite ou la gauche en fonction de la scale du perso quand on appuie
// sur shift . Le perso bouge psk on lui ajoute de la velocité . La gravité est désactivé pendant le dash

public class Esprit_Dash : MonoBehaviour
{
    public float dashLenght;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public Esprit_Stamina Stamina;

    void Update()
    {
        //désactive la gravité pendant le dash
        if (rb.velocity.x > 10)
        {
            rb.GetComponent<Rigidbody2D>().gravityScale = 0f;

        }
        else
        {
            rb.GetComponent<Rigidbody2D>().gravityScale = 2f;

        }

        // transform.localScale.x > 0f true si le perso regarde a droite 
        if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x + dashLenght, rb.velocity.y);
            Stamina.ReduceStamina(10);
        }
        // transform.localScale.x > 0f true si le perso regarde a gauche 
        else if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x < 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x - dashLenght, rb.velocity.y);
            Stamina.ReduceStamina(10);
        }
    }


}
