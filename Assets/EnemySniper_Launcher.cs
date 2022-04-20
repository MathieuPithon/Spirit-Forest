using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper_Launcher : MonoBehaviour
{
    public EnemySniper_RangeArea range;


    void Update()
    {

        if (range.inRange)
        {
            Debug.Log("piou piou");
        }

    }
}
