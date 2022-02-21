using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esprit_Combat : MonoBehaviour
{
    [HideInInspector]
    public bool isInCombat;
    public Transform attackPos;
    public float attackRange;
    public LayerMask enemies;
    public int damage;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Combat();
        }
    }


    void Combat()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyHealthManager>().HurtEnemy(damage);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}


