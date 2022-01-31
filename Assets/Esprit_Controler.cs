using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cyriaque - Fait tous les if est lance les differents scripts

public class Esprit_Controler : MonoBehaviour
{
    public Esprit_Mouvement Esprit_Mouvement;
    void Start()
    {

    }

    void Update()
    {
        Esprit_Mouvement.EspritMouvement();

    }
}
