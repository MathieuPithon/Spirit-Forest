using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    PlayerCombat combat;
    public float colliderCd = 0.2f;
    public float speed;
    public float range;
    private bool comeBack;
    private bool facingRight;
    private float comeBackRange;
    public int boomerangDamage;
    private int enemyLayer = 9;
    private int boomerangLayer = 12;
    
    void Start()
    {
        Physics2D.IgnoreLayerCollision(enemyLayer, boomerangLayer, false);
        comeBackRange = range * 3/2;
        combat = GameObject.Find("Player").GetComponent<PlayerCombat>();
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("ComeBack", range);
        boomerangDamage += (combat.strength / 4);//Degats du boomerang + modificateur de force
        if (!combat.faceRight)
            facingRight = false;
        else facingRight = true;        
    }
    void FixedUpdate()
    {
        if (facingRight)//Déplacement du boomerang
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
        if (collision.gameObject.tag == "Enemy")
        {
            
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(boomerangDamage);
            StartCoroutine(IgnoreColliderCd(enemyLayer, boomerangLayer, colliderCd));
        }
        if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);            
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (comeBack)
                Destroy(gameObject);
            ComeBack();
        }
    }  
    private void ComeBack()
    {
        comeBack = true;
        Destroy(gameObject, comeBackRange);        
    }
    public IEnumerator IgnoreColliderCd(int layer1, int layer2, float timer)
    {
        Physics2D.IgnoreLayerCollision(layer1, layer2, true);
        yield return new WaitForSeconds(timer);
        Physics2D.IgnoreLayerCollision(layer1, layer2, false);
    }
}
