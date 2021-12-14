using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptCombat : MonoBehaviour
{

    public int damageToTake;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageToTake, false);
        }
    }
}
