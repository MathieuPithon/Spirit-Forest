using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    Augmente temporairement la hauteur du saut de base du personnage
**/
public class PickUpJumpBuff : MonoBehaviour
{
    public PlayerBuffs playerBuffs;
    public int jumpBuff = 300;
    public float buffTimer = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //playerBuffs = GameObject.Find("Player").GetComponent<PlayerBuffs>();
            playerBuffs.BuffJumpForce(jumpBuff, buffTimer);
            Destroy(gameObject);
        }
    }
}
