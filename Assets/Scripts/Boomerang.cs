using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    //Animator animator
    Object boomerangRef;
    public PlayerCombat combat;
    public float range;
    public LayerMask enemyLayers;
    public float boomerangCd = 3f;
    public bool boomerangAvailable = true;

    void Start()
    {
        boomerangRef = Resources.Load("Boomerang");
        //animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && boomerangAvailable)
        {
            //Animator.Play("PlayerShoot");
            boomerangAvailable = false;
            GameObject boomerang = (GameObject)Instantiate(boomerangRef);
            if(combat.faceRight)
                boomerang.transform.position = new Vector3(transform.position.x + 1f, transform.position.y + .2f, -1);
            else if(!combat.faceRight)
                boomerang.transform.position = new Vector3(transform.position.x - 1f, transform.position.y + .2f, -1);
            StartCoroutine(BoomerangCd());
        }
    }
    private IEnumerator BoomerangCd()//Pour éviter de lancer 10 boomerangs à la suite
    {
        yield return new WaitForSeconds(boomerangCd);
        boomerangAvailable = true;
    }
}
