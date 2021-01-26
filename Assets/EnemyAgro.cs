using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    Animator animator;
    [SerializeField]//pour rendre la variable private mais pouvoir quand meme editer sur Unity
    Transform player;
    [SerializeField]
    float agroRange;
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        //distance avec le player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if(distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            //L'ennemi est à gauche du player donc va à droite
            rb2d.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            //L'ennemi est à droite du player donc va à gauche
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1); //pour faire regarder l'ennemi de l'autre coté
        }
        animator.Play("SnakeMovement");
    }
}
