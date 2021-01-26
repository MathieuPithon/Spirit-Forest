using System.Collections;

using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public int maxStamina = 100;
    private float currentStamina;
    public float staminaRegenSpeed = 0.025f;
    public float staminaRegen = 0.5f;
    private readonly int staminaRoutineFit = 2;
    
    public float CurrentStamina { get { return currentStamina; }
                            set {currentStamina = Mathf.Clamp( value, 0, maxStamina); } }

    public bool needStamina = false;
    private bool staminaRegenInProgress = false;
    public StaminaBar staminaBar;

    void Start()
    {
        CurrentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
        staminaBar.SetStamina(maxStamina);
    }
    public void LoseStamina(int staminaUsed)
    {
        CurrentStamina -= staminaUsed;
        staminaBar.SetStamina(CurrentStamina);
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
            if (CurrentStamina > maxStamina - staminaRoutineFit)
            {
                CurrentStamina = maxStamina - staminaRoutineFit;
                staminaRegenInProgress = false;                
                needStamina = false;
                StopCoroutine(StaminaRegen());
            }
            CurrentStamina += staminaRegen;
            staminaBar.SetStamina(CurrentStamina);
            yield return new WaitForSeconds(staminaRegenSpeed);
            CurrentStamina += staminaRegen;
            staminaBar.SetStamina(CurrentStamina);
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
