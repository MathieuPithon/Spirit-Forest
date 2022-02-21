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
    private float startTime;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Combat(20);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startTime = Time.time;
        }
        if (Input.GetKey(KeyCode.Mouse0) && Time.time - startTime > 1f)
        {
            Combat(40);
            startTime = Time.time;
        }
    }


    void Combat(int dmg)
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyHealthManager>().HurtEnemy(dmg);
            Debug.Log("enenenenen");
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}


