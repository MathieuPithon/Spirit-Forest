using UnityEngine;

/**
    Augmente temporairement l'énergie de base du personnage
    L'énergie permet de sauter et de taper
**/
public class PickUpStaminaBuff : MonoBehaviour
{
    //PlayerBuffs playerBuffs;
    public PlayerBuffs playerBuffs;
    public int staminaBuff = 40;
    public float buffTimer = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //playerBuffs = GameObject.Find("Player").GetComponent<PlayerBuffs>();
            playerBuffs.BuffStamina(staminaBuff, buffTimer);
            Destroy(gameObject);
        }
    }
}
