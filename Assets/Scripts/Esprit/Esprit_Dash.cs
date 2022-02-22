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
    public GameObject esprit;
    private bool cd = false;

    void Update()
    {
        if (!cd)
        {
            // transform.localScale.x > 0f true si le perso regarde a droite 
            if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x + dashLenght, rb.velocity.y);
                Stamina.ReduceStamina(10);
                esprit.GetComponent<Animator>().Play("PlayerDash");
                StartCoroutine(DelayCd());
            }
            // transform.localScale.x > 0f true si le perso regarde a gauche 
            else if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x < 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x - dashLenght, rb.velocity.y);
                Stamina.ReduceStamina(10);
                esprit.GetComponent<Animator>().Play("PlayerDash");
                StartCoroutine(DelayCd());
            }
        }
    }

    IEnumerator DelayCd()
    {
        cd = true;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(0.15f);
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(3f);
        cd = false;
    }

}
