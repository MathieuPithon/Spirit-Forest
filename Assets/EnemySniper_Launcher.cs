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
    private bool inCD;

    void Start(){
        esprit = GameObject.FindGameObjectsWithTag("Player");
        player = esprit[0];
    }
    IEnumerator TimerCDAttack()
    {
        yield return new WaitForSeconds(CDAttack);
        inCD = false;
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

    void Shoot()
    {
        Vector3 origin = firePoint.position;
        Vector3 end = player.transform.position;
        Vector3 direction = end - origin;
        Debug.Log(end);

        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, direction);
        if (hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);

        }
    }

    void Update()
    {

        if (range.inRange && inCD == false)
        {
            inCD = true;
            Shoot();
            StartCoroutine(TimerCDAttack());
        }

        if (turn.needTurn)
        {
            rotationSniper();
        }

    }
}


