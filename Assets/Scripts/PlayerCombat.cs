using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemyLayers;
    public GameObject player;
    public GameObject indicateurHaut;
    public GameObject indicateurBas;
    public SpriteRenderer spriteRenderer;

    public Transform attackStaticLightUpPoint;
    public Transform attackStaticLightDownPoint;
    public Transform attackForwardLightUpPoint;
    public Transform attackForwardLightDownPoint;
    public Transform attackBackwardLightUpPoint;
    public Transform attackBackwardLightDownPoint;
    public Transform attackUpLightUpPoint;
    public Transform attackDownLightDownPoint;

    public int damageToGive = 40;
    public float attackRange = 0.5f;
    public bool placement = true; // Placement de garde Haute (true) ou Basse (false)
    public bool faceRight = true; // Sens dans lequel le personnage est tourné, (true => Droite ; false => Gauche)
    public int strength = 40;

    
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource sound4;

    private int compteur = 0 ;

    


    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Input.GetKey("right"))
            {
                if (placement == true)
                {
                    if (faceRight == true)                    
                        AttackForwardLightUp();                   
                    else                    
                        AttackBackwardLightUp();                    
                }
                else
                {
                    if (faceRight == true)                    
                        AttackForwardLightDown();                    
                    else
                        AttackBackwardLightDown();
                    }
            }
            else if (Input.GetKey("left"))
            {
                if (placement == true)
                {
                    if (faceRight == true)                    
                        AttackBackwardLightUp();                    
                    else                    
                        AttackForwardLightUp();                    
                }
                else
                {
                    if (faceRight == true)                    
                        AttackBackwardLightDown();                    
                    else                    
                        AttackForwardLightDown();                    
                }
            }
            else if (Input.GetKey("up"))            
                AttackUpLightUp();            
            else if (Input.GetKey("down"))            
                AttackDownLightDown();            
            else
            {
                if (placement == true)                
                    AttackStaticLightUp();                
                else                
                    AttackStaticLightDown();                
            }
        }
        CombatIndicateur();
        
    }


    void sound()
    {
        compteur++;
        if (compteur == 5)
        {
            compteur = 1;
        }

        if(compteur == 1)
        {
            sound1.Play();

        }
        if (compteur == 2)
        {
            sound2.Play();
           
        }
        if (compteur == 3)
        {
            sound3.Play();
            
        }
        else
        {
            sound4.Play();
            
        }
    }
    void AttackStaticLightUp()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        sound();

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackStaticLightUpPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }
    }
    void AttackStaticLightDown()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        sound();

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackStaticLightDownPoint.position, attackRange, enemyLayers);
        

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }
    }
    void AttackForwardLightUp()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        sound();

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackForwardLightUpPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }
    }
    void AttackForwardLightDown()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        sound();

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackForwardLightDownPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }
    }
    void AttackBackwardLightUp()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        sound();

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackBackwardLightUpPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }
    }
    void AttackBackwardLightDown()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        sound();

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackBackwardLightDownPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }
    }
    void AttackUpLightUp()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        sound();

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackUpLightUpPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }
    }
    void AttackDownLightDown()
    {
        // Jouer l'animation d'attaque
        animator.SetTrigger("Attack");

        sound();

        // Detecter les ennemis dans la zonne d'attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackDownLightDownPoint.position, attackRange, enemyLayers);

        // Effectuer les dégats sur les ennemis
        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);            
        }
    }


    void OnDrawGizmosSelected()
    {
        if (attackStaticLightUpPoint == null)
            return;
        Gizmos.DrawWireSphere(attackStaticLightUpPoint.position, attackRange);

        if (attackStaticLightDownPoint == null)
            return;
        Gizmos.DrawWireSphere(attackStaticLightDownPoint.position, attackRange);

        if (attackForwardLightUpPoint == null)
            return;
        Gizmos.DrawWireSphere(attackForwardLightUpPoint.position, attackRange);

        if (attackForwardLightDownPoint == null)
            return;
        Gizmos.DrawWireSphere(attackForwardLightDownPoint.position, attackRange);

        if (attackBackwardLightUpPoint == null)
            return;
        Gizmos.DrawWireSphere(attackBackwardLightUpPoint.position, attackRange);

        if (attackBackwardLightDownPoint == null)
            return;
        Gizmos.DrawWireSphere(attackBackwardLightDownPoint.position, attackRange);

        if (attackUpLightUpPoint == null)
            return;
        Gizmos.DrawWireSphere(attackUpLightUpPoint.position, attackRange);

        if (attackDownLightDownPoint == null)
            return;
        Gizmos.DrawWireSphere(attackDownLightDownPoint.position, attackRange);

    }

     public void CombatIndicateur()
    {
        if (Input.GetKey("down"))
        {
            indicateurBas.SetActive(true);
            indicateurHaut.SetActive(false);
            placement = false;
        }
        else if (Input.GetKey("up") || Input.mousePosition.y > player.transform.position.y + 330)
        {
            indicateurHaut.SetActive(true);
            indicateurBas.SetActive(false);
            placement = true;
        }
        else if (Input.mousePosition.y < player.transform.position.y + 330)
        {
            indicateurBas.SetActive(true);
            indicateurHaut.SetActive(false);
            placement = false;
        }

        if (Input.mousePosition.x > player.transform.position.x + 480)
        {
            faceRight = true;
            spriteRenderer.transform.localScale = new Vector3(0.21f, 0.17f, 1);
        }
        else
        {
            faceRight = false;
            spriteRenderer.transform.localScale = new Vector3(-0.21f, 0.17f, 1);
        }
    }
}
