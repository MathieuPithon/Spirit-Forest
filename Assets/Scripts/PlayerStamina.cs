using System.Collections;

using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public int maxStamina = 100;
    public float currentStamina;
    public float staminaRegenSpeed = 0.025f;
    public float staminaRegen = 0.5f;
    private readonly int staminaRoutineFit = 2;

    public bool needStamina = false;
    private bool staminaRegenInProgress = false;
    public StaminaBar staminaBar;

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
        staminaBar.SetStamina(maxStamina);
    }
    public void LoseStamina(int staminaUsed)
    {           
        currentStamina -= staminaUsed;
        staminaBar.SetStamina(currentStamina);
        needStamina = true;
        if(needStamina && !staminaRegenInProgress)
        {            
            staminaRegenInProgress = true;
            StartCoroutine(StaminaRegen());
        }        
    }
    public IEnumerator StaminaRegen()
    {
        while(needStamina)//Fonctionne mais améliorable
        {
            if (currentStamina > maxStamina - staminaRoutineFit)
            {
                currentStamina = maxStamina - staminaRoutineFit;
                staminaRegenInProgress = false;                
                needStamina = false;
                StopCoroutine(StaminaRegen());
            }
            currentStamina += staminaRegen;
            staminaBar.SetStamina(currentStamina);
            yield return new WaitForSeconds(staminaRegenSpeed);
            currentStamina += staminaRegen;
            staminaBar.SetStamina(currentStamina);
            yield return new WaitForSeconds(staminaRegenSpeed);            
        }        
    }
    public void CallStaminaRegen()
    {
        needStamina = true;
        staminaRegenInProgress = true;
        StartCoroutine(StaminaRegen());
    }
}
