using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    PlayerCombat combat;
    public float speed;
    public float range;
    public bool comeBack = false;
    private bool facingRight;
    private float comeBackRange;
    public int boomerangDamage;//les dégats sont multipliés par 2 alors attention à la valeur renseignée dans l'inspector
    void Start()
    {
        comeBackRange = range * 3/2;
        combat = GameObject.Find("Player").GetComponent<PlayerCombat>();
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("ComeBack", range);
        if (!combat.faceRight)
            facingRight = false;
        else facingRight = true;
    }
    


    void FixedUpdate()
    {
        if (facingRight)
        {
            rb2d.velocity = new Vector2(speed, 0);
            if (comeBack)
                rb2d.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(-speed, 0);
            if (comeBack)
                rb2d.velocity = new Vector2(speed, 0);
        }
        
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(boomerangDamage);
            if (comeBack)
                Destroy(gameObject);
            ComeBack();
        }            
        if (collision.gameObject.CompareTag("Player") && comeBack)
            Destroy(gameObject);
    }
  
    private void ComeBack()
    {
        comeBack = true;
        Destroy(gameObject, comeBackRange);
        
    }
}
