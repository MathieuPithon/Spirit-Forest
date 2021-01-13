using System.Collections;
using UnityEngine;

public class PlayerBuffs : MonoBehaviour
{   
    public PlayerHealth playerHealth;
    public PlayerStamina playerStamina;
    public HealthBar healthBar;
    public StaminaBar staminaBar;

    private int healthBuffed;
    private int maxHealthBeforeBuff;
    public int healthKeeper = 10;

    private int staminaBuffed;
    private int maxStaminaBeforeBuff;

    //HEALTH BUFF
    public void BuffHealth(int healthBuff, float buffTimer)
    {
        maxHealthBeforeBuff = playerHealth.maxHealth;
        healthBuffed = playerHealth.maxHealth + healthBuff;
        playerHealth.maxHealth = healthBuffed;
        playerHealth.currentHealth += healthBuff;
        healthBar.SetMaxHealth(playerHealth.maxHealth);
        healthBar.SetHealth(playerHealth.currentHealth);
        StartCoroutine(HealthBuffTimer(healthBuff, buffTimer));
    }    
    public IEnumerator HealthBuffTimer(int healthBuff, float buffTimer)
    {
        yield return new WaitForSeconds(buffTimer);
        playerHealth.maxHealth = maxHealthBeforeBuff;//Unbuff
        playerHealth.currentHealth -= (healthBuff / 2);
        if (playerHealth.currentHealth > playerHealth.maxHealth)
            playerHealth.currentHealth = playerHealth.maxHealth;
        else if (playerHealth.currentHealth < healthKeeper)//Si le héros meurt a cause de la fin du buff
            playerHealth.currentHealth = healthKeeper;

        healthBar.SetMaxHealth(playerHealth.maxHealth);
        healthBar.SetHealth(playerHealth.currentHealth);
    }

    //STAMINA BUFF
    public void BuffStamina(int staminaBuff, float buffTimer)
    {
        maxStaminaBeforeBuff = playerStamina.maxStamina;
        staminaBuffed = playerStamina.maxStamina + staminaBuff;
        playerStamina.maxStamina = staminaBuffed;
        playerStamina.CallStaminaRegen();//Pour lancer la regen
        staminaBar.SetMaxStamina(playerStamina.maxStamina);
        staminaBar.SetStamina(playerStamina.currentStamina);
        StartCoroutine(StaminaBuffTimer(buffTimer));
    }
    public IEnumerator StaminaBuffTimer(float buffTimer)
    {
        yield return new WaitForSeconds(buffTimer);
        playerStamina.maxStamina = maxStaminaBeforeBuff; //Unbuff
        if (playerStamina.currentStamina > playerStamina.maxStamina)
            playerStamina.currentStamina = playerStamina.maxStamina;

        staminaBar.SetMaxStamina(playerStamina.maxStamina);
        staminaBar.SetStamina(playerStamina.currentStamina);
    }

}
