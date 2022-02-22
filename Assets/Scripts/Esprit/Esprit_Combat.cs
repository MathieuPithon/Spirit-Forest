using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Cyriaque - attaque lourde / attaque legere c'est le bordel demandé irl si pb
public class Esprit_Combat : MonoBehaviour
{
    [HideInInspector]
    public bool isInCombat;
    public Transform attackPos;
    public float attackRange;
    public LayerMask enemies;
    private float startTime;
    public Animator anim;
    private bool letGo = true;
    private bool cantAttack;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && cantAttack == false)
        {
            Combat(20);
            StartCoroutine(Delay(0.25f));
            anim.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startTime = Time.time;
        }
        if (Input.GetKey(KeyCode.Mouse0) && Time.time - startTime > 1f && letGo && cantAttack == false)
        {
            Combat(40);
            StartCoroutine(Delay(2f));
            anim.SetTrigger("Attack");
            startTime = Time.time;
            letGo = false;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            letGo = true;
        }
    }


    void Combat(int dmg)
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyHealthManager>().HurtEnemy(dmg);
        }
    }

    IEnumerator Delay(float time)
    {
        cantAttack = true;
        yield return new WaitForSeconds(time);
        cantAttack = false;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}


