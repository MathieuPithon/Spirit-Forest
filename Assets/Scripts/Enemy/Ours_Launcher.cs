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
    private bool inCDattack = false;
    private bool inCDscream = false;


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

    IEnumerator inCDattackCD()
    {
        yield return new WaitForSeconds(4f);
        animAttack = false;
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

    private void scream(){

    }

    void Update()
    {
        if (rangeArea.seePlayer && !animAttack && !inCDattack)
        {
            attack();
        }
        if (platfromArea.onPlatfrom && !animAttack && !inCDscream)
        {
            scream();
        }
    }
}
