using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cyriaque - Fait tous les if est lance les differents scripts

public class Esprit_Controler : MonoBehaviour
{
    public Esprit_Mouvement Esprit_Mouvement;
    public Esprit_Jump Esprit_Jump;
    void Start()
    {

    }

    void FixedUpdate()
    {
        Esprit_Mouvement.Mouvement();
        if (Input.GetButtonDown("Jump"))
        {
            Esprit_Jump.Jump();
            Debug.Log("testostestas");
        }
    }
}
