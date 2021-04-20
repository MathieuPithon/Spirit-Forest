using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamouraiLauncher : MonoBehaviour
{
    public int CoolDown;
    public int CDAttacking;
    public goBack goBack;
    public agro agro;
    public turn turn;
    public Transform gate;
    public attackArea attackArea;


    private Animator anim;
    public Transform cible;
    private Vector3 scaleChange;
    private Vector3 vecZero = new Vector3(0, 0, 0);

    public bool inCoolDown = false;
    public bool isAttacking = false;
    private bool faceLeft;


    //fonction attaque
    void attack()
    {
        isAttacking = true;
        inCoolDown = true;
        StartCoroutine(TimerCDAttacking());
        StartCoroutine(TimerCoolDown());
    }

    //coroutine cd attack
    IEnumerator TimerCDAttacking()
    {
        yield return new WaitForSeconds(CDAttacking);
        isAttacking = false;
    }

    //coroutine cd CoolDown
    IEnumerator TimerCoolDown()
    {
        yield return new WaitForSeconds(CoolDown);
        inCoolDown = false;
    }

    //fonction mouvement
    void mouvement()
    {
        Vector3 vecAgro = cible.position.Y() - transform.position.Y();
        transform.Translate(vecAgro.normalized * 4 * Time.deltaTime, Space.World);

    }

    //fonction retour a la base
    void backToBase()
    {
        if (transform.position.x > gate.position.x)
        {
            Vector3 vecGate = gate.position.Y() - transform.position.Y();
            transform.Translate(vecGate.normalized * 2 * Time.deltaTime, Space.World);
        }
        else
        {
            Vector3 vecGate = gate.position.Y() - transform.position.Y();
            transform.Translate(vecGate.normalized * 2 * Time.deltaTime, Space.World);
        }
    }

    //fonction recule si joueur trop proche
    void goBackward()
    {
        if (faceLeft == true)
        {
            Vector3 vecGoBack = transform.position.Y() - cible.position.Y();
            transform.Translate(vecGoBack.normalized * 2 * Time.deltaTime, Space.World);
        }
        else
        {
            Vector3 vecGoBack = cible.position.Y() + transform.position.Y();
            transform.Translate(vecGoBack.normalized * 2 * Time.deltaTime, Space.World);
        }
    }

    //fonction rotation vers le joueur
    void rotationPlayer()
    {
        if (faceLeft == true)
        {
            scaleChange = new Vector3(-0.4f, 0f, 0f);
            faceLeft = false;
        }
        else
        {
            scaleChange = new Vector3(0.4f, 0f, 0f);
            faceLeft = true;
        }

        transform.localScale += scaleChange;
        turn.needTurn = false;
    }

    //fonction rotation vers la gate
    void rotationGate()
    {
        if (faceLeft == true)
        {
            scaleChange = new Vector3(0.4f, 0f, 0f);
        }
        else
        {
            scaleChange = new Vector3(-0.4f, 0f, 0f);
        }

        transform.localScale += scaleChange;
        turn.needTurn = false;
    }


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        anim.SetBool("attack", true);
        float ecareGate = Vector2.Distance(gate.position, transform.position);

        //if attack
        if (attackArea.inRange == true && inCoolDown == false)
        {
            attack();
            
        }

        //if mouvement
        if (attackArea.inRange == false && agro.seePlayer == true && isAttacking == false && goBack.needBack == false)
        {

            mouvement();
            
        }

        //if retour a la base
        if (agro.seePlayer == false && isAttacking == false && ecareGate > 1)
        {
            backToBase();
            
        }

        //if recul
        if (goBack.needBack == true && isAttacking == false)
        {

            goBackward();
            
        }

        //if rotation player
        if (turn.needTurn == true && isAttacking == false)
        {
            rotationPlayer();
        }



    }
}