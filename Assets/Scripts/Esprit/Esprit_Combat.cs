using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Cyriaque - attaque lourde / attaque legere c'est le bordel demandé irl si pb
public class Esprit_Combat : MonoBehaviour
{
    public Transform attackPos;
    public float attackRange;
    public LayerMask enemies;
    private float startTime;
    public Animator anim;
    private bool letGo = true;
    private bool cantAttack;
    private int compteur = 1;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource sound4;


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
        if (Input.GetKey(KeyCode.Mouse0) && Time.time - startTime > 0.25f && letGo && cantAttack == false)
        {
            StartCoroutine(Delay(2f));
            anim.SetTrigger("HeavyAttack");
            startTime = Time.time;
            letGo = false;
            StartCoroutine(HeavyAttack());
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
        sound();
    }

    IEnumerator Delay(float time)
    {
        cantAttack = true;
        yield return new WaitForSeconds(time);
        cantAttack = false;
    }

    IEnumerator HeavyAttack()
    {
        yield return new WaitForSeconds(1.21f);
        Combat(40);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }


    void sound()
    {
        compteur++;
        if (compteur == 5)
        {
            compteur = 1;
        }

        if (compteur == 1)
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
}

