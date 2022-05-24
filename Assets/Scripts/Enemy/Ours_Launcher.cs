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
    public SpriteRenderer spriteRenderer;
    public turnArea turnArea;
    public Animator animator;
    private Vector3 scaleChange;
    private bool faceLeft;
    public float speed = 0;
    public AudioSource audioScream;
    public hitCharge hited;



    private bool animAttack = false;
    private bool animScream = false;
    private bool inCDattack = false;
    private bool inCDscream = false;
    private bool animCharge = false;
    private bool inCDcharge = false;
    private bool overideCharge = false;
    private bool CoroutineCharge = true;
    private int goLeft;
    private bool anim = false;
    private bool hitWall = false;

    void Start()
    {
        esprit = GameObject.FindGameObjectsWithTag("Player");
        player = esprit[0];
        StartCoroutine(WaitBeginning());

    }

    IEnumerator AnimeAttackCD()
    {
        yield return new WaitForSeconds(1.5f);
        animAttack = false;
        animator.SetBool("attack", false);
    }
    IEnumerator AnimeScreamCD()
    {
        yield return new WaitForSeconds(1.5f);
        animScream = false;
        animator.SetBool("scream", false);
    }
    IEnumerator AnimeChargeCD()
    {
        yield return new WaitForSeconds(3f);
        animCharge = false;
    }

    IEnumerator AnimeHitWallCD()
    {
        yield return new WaitForSeconds(2.5f);
        hitWall = false;
        Debug.Log("HitWall CoroutineCharge");
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
        yield return new WaitForSeconds(8f);
        inCDcharge = false;
        CoroutineCharge = true;
    }

    IEnumerator WaitBeginning()
    {
        yield return new WaitForSeconds(5f);
    }
    private void attack()
    {
        animator.SetBool("attack", true);
        //start animation attack
        player.GetComponent<Esprit_Health>().TakeDamage(20);
        animAttack = true;
        StartCoroutine(AnimeAttackCD());
        inCDattack = true;
        StartCoroutine(inCDattackCD());
    }

    private void scream()
    {
        audioScream.Play();
        animator.SetBool("scream", true);
        //start animation scream
        animScream = true;
        StartCoroutine(AnimeScreamCD());
        inCDscream = true;
        StartCoroutine(inCDscreamCD());
    }

    private void charge()
    {
        
        if (hited.hited)
        {
            print("vdsssss");
            overideCharge = false;
            return;
        }
        //player entre le mur gauche et l'ours
        if (!inCDcharge)
        {

            if (transform.position.x - leftWall.transform.position.x > player.transform.position.x - leftWall.transform.position.x)
            {
                goLeft = 1;
            }
            else
            {
                goLeft = -1;
            }
        }

        if (CoroutineCharge)
        {
            CoroutineCharge = false;
            animCharge = true;
            StartCoroutine(AnimeChargeCD());
            /*
            if (transform.position.x - leftWall.transform.position.x < 1F || rightWall.transform.position.x - transform.position.x < 1f)
            {
                HitWall();
                animator.SetBool("hitWall", false);
            }
            */
            inCDcharge = true;
            StartCoroutine(inCDchargeCD());

        }

        if (leftWall.transform.position.x <= transform.position.x && animCharge)
        {

            overideCharge = true;
        }
        else
        {
            overideCharge = false;
        }
        Vector3 vecAgro = leftWall.transform.position.Y() - transform.position.Y();
        transform.Translate(vecAgro.normalized * goLeft * 10 * Time.deltaTime, Space.World);

        
        
        
        

    }

    void Flip()
    {
        if (faceLeft == true)
        {
            scaleChange = new Vector3(2f, 0f, 0f);
            faceLeft = false;
        }
        else
        {
            scaleChange = new Vector3(-2f, 0f, 0f);
            faceLeft = true;
        }

        transform.localScale += scaleChange;
        turnArea.needTurn = false;
    }

    void HitWall()
    {
        //audioWallHitted.Play();
        animator.SetBool("hitWall",true);
        hitWall = true;
        StartCoroutine(AnimeHitWallCD());

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
        if (turnArea.needTurn && anim)
        {
            Flip();
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
            //animator.SetBool("hitWall",false);
        }
        
        if (!platfromArea.onPlatfrom && !rangeArea.seePlayer && groundArea.isGrounded && inCDcharge && anim)
        {
            Vector3 vecAgro = player.transform.position.Y() - transform.position.Y();
            transform.Translate(vecAgro.normalized * 4 * Time.deltaTime, Space.World);
        }
    }



    Vector3 lastPosition = Vector3.zero;
    void FixedUpdate()
    {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        animator.SetFloat("speed", speed);
    }



}
