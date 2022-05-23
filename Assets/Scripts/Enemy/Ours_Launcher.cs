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

    private bool animAttack = false;
    private bool animScream = false;
    private bool inCDattack = false;
    private bool inCDscream = false;
    private bool needScream = false;

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

    private void attack()
    {
        //start animation attack
        player.GetComponent<Esprit_Health>().TakeDamage(20);
        animAttack = true;
        StartCoroutine(AnimeAttackCD());
        inCDattack = true;
        StartCoroutine(inCDattackCD());
    }

    private void scream()
    {
        //start animation scream
        animScream = true;
        StartCoroutine(AnimeScreamCD());
        inCDscream = true;
        StartCoroutine(inCDscreamCD());
    }

    void Update()
    {
        if (rangeArea.seePlayer && !animAttack && !inCDattack)
        {
            attack();
        }
        if ((platfromArea.onPlatfrom || needScream) && !animAttack && !inCDscream)
        {
            scream();
        }
    }
}
