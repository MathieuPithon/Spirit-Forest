using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public GameObject player;
    public GameObject indicateurHaut;
    public GameObject indicateurBas;

    public float attackRange = 0.5f;
    public bool placement = true; // Placement de garde Haute (true) ou Basse (false)
    public float currentStrength = 40;
    public float maxStrength = 40;  //Stat arbitraire pour créer la variable. A redéfinir

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        { 
            if(Input.GetKey("right"))
            {
                if(placement == true)
                {
                    AttackRightLightUp();
                    Debug.Log("AttackRightLightUp");
                }
                else
                {
                    AttackRightLightDown();
                    Debug.Log("AttackRightLightDown");
                }
            }
            else if(Input.GetKey("left"))
            {
                if (placement == true)
                {
                    AttackLeftLightUp();
                }
                else
                {
                    AttackLeftLightDown();
                }
            }
            else if(Input.GetKey("up"))
            {
                if (placement == true)
                {
                    AttackUpLightUp();
                }
                else
                {
                    AttackUpLightDown();
                }
            }
            else if(Input.GetKey("down"))
            {
                if (placement == true)
                {
                    AttackDownLightUp();
                }
                else
                {
                    AttackDownLightDown();
                }
            } 
            else
            {
                if (placement == true)
                {
                    AttackStaticLightUp();
                }
                else
                {
                    AttackStaticLightDown();
                }
            }
        }



        CombatIndicateur();

        
    }

    void AttackStaticLightUp()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " a été touché !");
        }
    }
    void AttackStaticLightDown()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " a été touché !");
        }
    }
    void AttackLeftLightUp()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " a été touché !");
        }
    }
    void AttackLeftLightDown()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " a été touché !");
        }
    }
    void AttackRightLightUp()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " a été touché !");
        }
    }
    void AttackRightLightDown()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " a été touché !");
        }
    }
    void AttackUpLightUp()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " a été touché !");
        }
    }
    void AttackUpLightDown()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " a été touché !");
        }
    }
    void AttackDownLightUp()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " a été touché !");
        }
    }
    void AttackDownLightDown()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " a été touché !");
        }
    }


    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void CombatIndicateur()
    {
        if (Input.mousePosition.y > player.transform.position.y+330)
        {
            indicateurHaut.SetActive(true);
            indicateurBas.SetActive(false);
            placement = true;
        } else
        {
            indicateurBas.SetActive(true);
            indicateurHaut.SetActive(false);
            placement = false;
        }
    }
}
