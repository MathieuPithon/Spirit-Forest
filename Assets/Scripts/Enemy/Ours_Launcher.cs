using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ours_Launcher : MonoBehaviour
{
    public groundArea groundArea;
    public platfromArea platfromArea;
    public rangeArea rangeArea;
    public GameObject[] esprit;
    public GameObject player;
    public GameObject leftWall;
    public GameObject rightWall;
    public Rigidbody2D rb;

    public bool animAttack = false;
    public bool animScream = false;
    public bool inCDattack = false;
    public bool inCDscream = false;
    public bool animCharge = false;
    public bool inCDcharge = false;
    public bool overideCharge = false;
    public int goLeft;

    private bool anim = false;
    void Start()
    {
        esprit = GameObject.FindGameObjectsWithTag("Player");
        player = esprit[0];
    }

    IEnumerator AnimeAttackCD()
    {
        yield return new WaitForSeconds(1.5f);
        animAttack = false;
    }
    IEnumerator AnimeScreamCD()
    {
        yield return new WaitForSeconds(1.5f);
        animScream = false;
    }
    IEnumerator AnimeChargeCD()
    {
        yield return new WaitForSeconds(1.5f);
        animCharge = false;
    }

    IEnumerator inCDattackCD()
    {
        yield return new WaitForSeconds(4f);
        inCDattack = false;
    }

    IEnumerator inCDscreamCD()
    {
        yield return new WaitForSeconds(4f);
        inCDscream = false;
    }

    IEnumerator inCDchargeCD()
    {
        yield return new WaitForSeconds(4f);
        inCDcharge = false;
    }
    private void attack()
    {
        print("attack");
        //start animation attack
        player.GetComponent<Esprit_Health>().TakeDamage(20);
        animAttack = true;
        StartCoroutine(AnimeAttackCD());
        inCDattack = true;
        StartCoroutine(inCDattackCD());
    }

    private void scream()
    {
        print("scream");
        //start animation scream
        animScream = true;
        StartCoroutine(AnimeScreamCD());
        inCDscream = true;
        StartCoroutine(inCDscreamCD());
    }

    private void charge()
    {
        //player entre le mur gauche et l'ours
        if (transform.position.x - leftWall.transform.position.x > player.transform.position.x - leftWall.transform.position.x)
        {
            goLeft = -1;
        }
        else
        {
            goLeft = 1;
        }
        if (leftWall.transform.position.x <= transform.position.x)
        {

            overideCharge = true;
        }
        else
        {
            overideCharge = false;
        }
        print("charge");
        Vector3 vecAgro = leftWall.transform.position.Y() - transform.position.Y();
        transform.Translate(vecAgro.normalized * 50 * Time.deltaTime, Space.World);


        animCharge = true;
        StartCoroutine(AnimeChargeCD());
        inCDcharge = true;
        StartCoroutine(inCDchargeCD());
    }

    void Update()
    {
        if (!animAttack && !animScream && !animCharge)
        {
            anim = true;
        }
        else
        {
            anim = false;
        }
        if (rangeArea.seePlayer && !inCDattack && anim)
        {
            attack();
        }
        if (platfromArea.onPlatfrom && !inCDscream && anim)
        {
            scream();
        }
        if ((!platfromArea.onPlatfrom && !rangeArea.seePlayer && groundArea.isGrounded && !inCDcharge && anim) || overideCharge)
        {
            charge();
        }
    }
}
