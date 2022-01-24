using UnityEngine;

/**
    Augmente temporairement les pdv de base du personnage
**/
public class PickUpHealthBuff : MonoBehaviour
{
    //PlayerBuffs playerBuffs;
    public PlayerBuffs playerBuffs;
    public int healthBuff = 40;
    //Augmente de 40 pdv la vie du perso
    public float buffTimer = 2f;
    //pendant ce temps là

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //playerBuffs = GameObject.Find("Player").GetComponent<PlayerBuffs>();
            playerBuffs.BuffHealth(healthBuff, buffTimer);
            Destroy(gameObject);
        }
    }
}
