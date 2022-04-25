using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper_Launcher : MonoBehaviour
{
    public EnemySniper_RangeArea range;
    public EnemySniper_Turn turn;
    public Transform firePoint;
    public GameObject[] esprit;
    public GameObject player;
    public Esprit_Health esprit_Health;
    public LineRenderer lineRenderer;

    private Vector3 scaleChange;
    private bool faceLeft;
    public float CDAttack;
    public bool inCD;
    public bool aimed = false;


    void Start()
    {
        esprit = GameObject.FindGameObjectsWithTag("Player");
        player = esprit[0];
    }
    IEnumerator TimerCDAttack()
    {
        yield return new WaitForSeconds(CDAttack);
        inCD = false;
    }
    IEnumerator TimerAime()
    {
        yield return new WaitForSeconds(3f);
        aimed = true;
    }
    IEnumerator TimerShooting()
    {
        yield return new WaitForSeconds(0.5f);
        temp();
        aimed = false;
        inCD = true;
        StartCoroutine(TimerCDAttack());
    }



    void rotationSniper()
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
        turn.needTurn = false;
    }

    void setcolor(LineRenderer lineRenderer, Color newColor)
    {
        Gradient tempGradient = new Gradient();

        GradientColorKey[] tempColorkeys = new GradientColorKey[2];
        tempColorkeys[0] = new GradientColorKey(newColor, 0);
        tempColorkeys[1] = new GradientColorKey(newColor, 1);

        tempGradient.colorKeys = tempColorkeys;

        lineRenderer.colorGradient = tempGradient;
    }
    void Aime()
    {
        Vector3 origin = firePoint.position;
        Vector3 end = player.transform.position;
        Vector3 direction = end - origin;

        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, direction);
        if (hitInfo)
        {
            setcolor(lineRenderer, UnityEngine.Color.green);
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);

        }
    }


    void temp()
    {
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, firePoint.position);
    }
    void Update()
    {
        if (range.inRange && inCD == false && aimed == false)
        {
            Aime();
            StartCoroutine(TimerAime());
        }
        if (range.inRange && aimed)
        {
            setcolor(lineRenderer, UnityEngine.Color.red);

            StartCoroutine(TimerShooting());

        }

        if (turn.needTurn)
        {
            rotationSniper();
        }

    }
}


