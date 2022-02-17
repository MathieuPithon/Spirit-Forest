using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Esprit_Stamina : MonoBehaviour
{
    private int maxStamina = 100;
    private int currentStamina;
    public StaminaBar StaminaBar;
    private bool cd = false;

    void Start()
    {
        currentStamina = maxStamina;
        StaminaBar.SetMaxStamina(maxStamina);
    }


    void Update()
    {
        if (!cd)
        {
            RegenStamina();
        }
    }

    void ReduceStamina(int amount)
    {
        currentStamina -= amount;
        StaminaBar.SetStamina(currentStamina);
        Delay();
    }

    void RegenStamina() {
        
    }

    IEnumerator Delay()
    {
        cd = true;
        yield return new WaitForSeconds(3f);
        cd = false;
    }


}
