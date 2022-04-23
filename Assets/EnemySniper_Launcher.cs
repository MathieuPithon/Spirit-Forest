using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper_Launcher : MonoBehaviour
{
    public EnemySniper_RangeArea range;
    public EnemySniper_Turn turn;

    private Vector3 scaleChange;
    private bool faceLeft;
    public float CDAttack;
    private bool inCD;
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
    void Update()
    {

        if (range.inRange && inCD == false)
        {
            inCD = true;
            Debug.Log("piou piou");
            StartCoroutine(TimerCDAttack());
        }

        if (turn.needTurn)
        {
            rotationSniper();
        }

    }
}


