using System.Collections;
using UnityEngine;

public class PlayerBuffs : MonoBehaviour
{   
    public PlayerHealth health;
    public PlayerStamina stamina;
    public PlayerMovement movement;
    public HealthBar healthBar;
    public StaminaBar staminaBar;

    private int healthBuffed;
    private int maxHealthBeforeBuff;
    public int healthKeeper = 10;

    private int staminaBuffed;
    private int maxStaminaBeforeBuff;

    private float speedBuffed;
    private float regularSpeed;

    //HEALTH BUFF
    public void BuffHealth(int healthBuff, float buffTimer)
    {
        maxHealthBeforeBuff = health.maxHealth;
        healthBuffed = health.maxHealth + healthBuff;
        health.maxHealth = healthBuffed;
        health.currentHealth += healthBuff;
        healthBar.SetMaxHealth(health.maxHealth);
        healthBar.SetHealth(health.currentHealth);
        StartCoroutine(HealthBuffTimer(healthBuff, buffTimer));
    }    
    public IEnumerator HealthBuffTimer(int healthBuff, float buffTimer)
    {
        yield return new WaitForSeconds(buffTimer);
        health.maxHealth = maxHealthBeforeBuff;//Unbuff
        health.currentHealth -= (healthBuff / 2);
        if (health.currentHealth > health.maxHealth)
            health.currentHealth = health.maxHealth;
        else if (health.currentHealth < healthKeeper)//Si le héros meurt a cause de la fin du buff
            health.currentHealth = healthKeeper;

        healthBar.SetMaxHealth(health.maxHealth);
        healthBar.SetHealth(health.currentHealth);
    }

    //STAMINA BUFF
    public void BuffStamina(int staminaBuff, float buffTimer)
    {
        maxStaminaBeforeBuff = stamina.maxStamina;
        staminaBuffed = stamina.maxStamina + staminaBuff;
        stamina.maxStamina = staminaBuffed;
        stamina.CallStaminaRegen();//Pour lancer la regen
        staminaBar.SetMaxStamina(stamina.maxStamina);
        staminaBar.SetStamina(stamina.currentStamina);
        StartCoroutine(StaminaBuffTimer(buffTimer));
    }
    public IEnumerator StaminaBuffTimer(float buffTimer)
    {
        yield return new WaitForSeconds(buffTimer);
        stamina.maxStamina = maxStaminaBeforeBuff; //Unbuff
        if (stamina.currentStamina > stamina.maxStamina)
            stamina.currentStamina = stamina.maxStamina;

        staminaBar.SetMaxStamina(stamina.maxStamina);
        staminaBar.SetStamina(stamina.currentStamina);
    }

    //MoveSpeed Buff
    public void BuffSpeed(float speedBuff, float buffTimer)
    {
        regularSpeed = movement.moveSpeed;
        speedBuffed = movement.moveSpeed + speedBuff;
        movement.moveSpeed = speedBuffed;
        StartCoroutine(SpeedBuffTimer(buffTimer));
    }
    public IEnumerator SpeedBuffTimer(float buffTimer)
    {
        yield return new WaitForSeconds(buffTimer);
        movement.moveSpeed = regularSpeed;//Unbuff
    }
}
