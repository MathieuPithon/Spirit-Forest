using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Esprit_Stamina : MonoBehaviour
{
    private int maxStamina = 100;
    private float currentStamina;
    public StaminaBar StaminaBar;
    private bool cd = false;
    private bool cdRegene = false;

    void Start()
    {
        currentStamina = maxStamina;
        StaminaBar.SetMaxStamina(maxStamina);
    }


    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            StartCoroutine(ReduceStamina(50));
        }
        if (!cd && currentStamina < maxStamina && !cdRegene)
        {
            StartCoroutine(RegenStamina());
        }

        StaminaBar.SetStamina(currentStamina);
    }

    IEnumerator ReduceStamina(int amount)
    {
        currentStamina -= amount;
        StaminaBar.SetStamina(currentStamina);
        cd = true;
        yield return new WaitForSeconds(2f);
        cd = false;
    }

    IEnumerator RegenStamina()
    {
        currentStamina += 1.5f;
        cdRegene = true;
        yield return new WaitForSeconds(0.05f);
        cdRegene = false;
    }




}
