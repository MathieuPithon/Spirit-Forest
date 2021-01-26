using System.Collections;
using UnityEngine;

public class PlayerBuffs : MonoBehaviour
{   
    public PlayerHealth health;
    public PlayerStamina stamina;
    public PlayerMovement movement;
    public PlayerCombat strength;
    public HealthBar healthBar;
    public StaminaBar staminaBar;
    
    public int healthKeeper = 10;
    private int regularHealth;
    private int maxStaminaBeforeBuff;
    private int regularStrength;
    private float regularStaminaRegen;
    private float regularStaminaRegenSpeed;
    private float regularSpeed;
    private float regularJumpForce;
    

    //HEALTH BUFF
    public void BuffHealth(int healthBuff, float buffTimer)
    {
        regularHealth = health.maxHealth;
        health.maxHealth += healthBuff;
        health.CurrentHealth += healthBuff;
        healthBar.SetMaxHealth(health.maxHealth);
        healthBar.SetHealth(health.CurrentHealth);
        StartCoroutine(HealthBuffTimer(healthBuff, buffTimer));
    }    
    public IEnumerator HealthBuffTimer(int healthBuff, float buffTimer)
    {
        yield return new WaitForSeconds(buffTimer);
        health.maxHealth = regularHealth;//Unbuff
        health.CurrentHealth -= (healthBuff / 2);
        if (health.CurrentHealth > health.maxHealth)
            health.CurrentHealth = health.maxHealth;
        else if (health.CurrentHealth < healthKeeper)//Si le héros meurt a cause de la fin du buff
            health.CurrentHealth = healthKeeper;

        healthBar.SetMaxHealth(health.maxHealth);
        healthBar.SetHealth(health.CurrentHealth);
    }

    //STAMINA BUFF
    public void BuffStamina(int staminaBuff, float buffTimer)
    {
        maxStaminaBeforeBuff = stamina.maxStamina;
        stamina.maxStamina += staminaBuff;
        stamina.CallStaminaRegen();//Pour lancer la regen
        staminaBar.SetMaxStamina(stamina.maxStamina);
        staminaBar.SetStamina(stamina.CurrentStamina);
        StartCoroutine(StaminaBuffTimer(buffTimer));
    }
    public IEnumerator StaminaBuffTimer(float buffTimer)
    {
        yield return new WaitForSeconds(buffTimer);
        stamina.maxStamina = maxStaminaBeforeBuff; //Unbuff
        if (stamina.CurrentStamina > stamina.maxStamina)
            stamina.CurrentStamina = stamina.maxStamina;

        staminaBar.SetMaxStamina(stamina.maxStamina);
        staminaBar.SetStamina(stamina.CurrentStamina);
    }

    //STAMINA REGEN BUFF
    public void BuffStaminaRegen(float staminaRegenBuff, float regenSpeedBuff, float buffTimer)
    {
        regularStaminaRegen = stamina.staminaRegen;
        regularStaminaRegenSpeed = stamina.staminaRegenSpeed;
        stamina.staminaRegen += staminaRegenBuff;
        stamina.staminaRegenSpeed += regenSpeedBuff;
        StartCoroutine(RegenBuffTimer(buffTimer));
    }
    public IEnumerator RegenBuffTimer(float buffTimer)
    {
        yield return new WaitForSeconds(buffTimer);
        stamina.staminaRegen = regularStaminaRegen;
        stamina.staminaRegenSpeed = regularStaminaRegenSpeed;
    }

    //MOVESPEED Buff
    public void BuffSpeed(float speedBuff, float buffTimer)
    {
        regularSpeed = movement.moveSpeed;
        movement.moveSpeed += speedBuff;
        StartCoroutine(SpeedBuffTimer(buffTimer));
    }
    public IEnumerator SpeedBuffTimer(float buffTimer)
    {
        yield return new WaitForSeconds(buffTimer);
        movement.moveSpeed = regularSpeed;//Unbuff
    }

    //STRENGTH BUFF 
    public void BuffStrength(int strengthBuff, float buffTimer)
    {
        regularStrength = strength.strength;
        regularStrength += strengthBuff;
        StartCoroutine(StrengthBuffTimer(buffTimer));
    }
    public IEnumerator StrengthBuffTimer(float buffTimer)
    {
        yield return new WaitForSeconds(buffTimer);
        strength.strength = regularStrength;
    }

    //JUMP BUFF
    public void BuffJumpForce(float jumpBuff,float buffTimer)
    {
        regularJumpForce = movement.jumpForce;
        movement.jumpForce += jumpBuff;
        StartCoroutine(JumpBuffTimer(buffTimer));
    }
    public IEnumerator JumpBuffTimer(float buffTimer)
    {
        yield return new WaitForSeconds(buffTimer);
        movement.jumpForce = regularJumpForce;
    }
}
