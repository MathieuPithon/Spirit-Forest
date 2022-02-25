using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper_Launcher : MonoBehaviour
{
    public int CoolDown;
    public int CDAttacking;
    public EnemySniper_TurnAround turnAround; 
    public EnemySniper_Agro agro;
    public EnemySniper_AttackArea attackDistArea;
    public EnemySniper_CaCAttack attackCaCArea; 
    
    public Rigidbody2D rb;

    private Animator anim ;
    public Transform cible;
    private Vector3 scaleChange;
    private Vector3 vecZero = new Vector3(0,0,0);

    public bool inCoolDown  =false;  
    public bool isAttacking = false; 
    private bool faceLeft;
    public Animator animator;


    void attack()
    {
        isAttacking =true;
        inCoolDown = true;
        //StartCoroutine(TimerCDAttacking());
        //StartCoroutine(TimerCoolDown());

    }
}