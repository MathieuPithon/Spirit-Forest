﻿using UnityEngine.UI;
using UnityEngine;

public class CaracteristicsWindow : MonoBehaviour
{
   
    public GameObject caracteristicsUI;
    public GameObject levelUpUI;
    public PlayerHealth playerHealth;
    public PlayerStamina playerStamina;
    public PlayerXp playerXp;
    public PlayerCombat playerStrength;
    public PauseMenu pauseMenu;
    public HealthBar healthBar;
    public StaminaBar staminaBar;

    public int upHealth = 20;
    public int upStamina = 10;
    public int upStrength = 5;
    public bool isOpen = false;

    public Text healthValue;
    public Text maxHealthValue;
    public Text staminaValue;
    public Text maxStaminaValue;
    public Text xpValue;
    public Text maxXpValue;
    public Text strengthValue;
    public Text maxStrengthValue;

    public Text upHealthValue;
    public Text upStaminaValue;
    public Text upStrengthValue;
   
    void Update()
    {
        healthValue.text = playerHealth.currentHealth.ToString();
        maxHealthValue.text = playerHealth.maxHealth.ToString();
        staminaValue.text = playerStamina.currentStamina.ToString();
        maxStaminaValue.text = playerStamina.maxStamina.ToString();
        xpValue.text = playerXp.currentXp.ToString();
        maxXpValue.text = playerXp.maxXp.ToString();
        strengthValue.text = playerStrength.currentStrength.ToString();
        maxStrengthValue.text = playerStrength.maxStrength.ToString();

        upHealthValue.text = "+" + upHealth.ToString();
        upStaminaValue.text = "+" + upStamina.ToString();
        upStrengthValue.text = "+" + upStrength.ToString();


        if (Input.GetKeyDown(KeyCode.C) && (!PauseMenu.gameIsPaused))
        {
            if (isOpen)
            {
                caracteristicsUI.SetActive(false);//Ferme la fenetre
                isOpen = false;                   
            }
            else
            {
                caracteristicsUI.SetActive(true); //Ouvre la fenetre
                isOpen = true;
                if (playerXp.levelUp)
                {
                    levelUpUI.SetActive(true);
                }
                else
                {
                    levelUpUI.SetActive(false);
                }
            }
        }
    }
    public void UpHealth()
    {
        playerHealth.maxHealth += upHealth;
        playerXp.levelUp = false;
        healthBar.SetMaxHealth(playerHealth.maxHealth); //mise à jour de la barre de vie
        levelUpUI.SetActive(false);
    }
    public void UpStamina()
    {
        playerStamina.maxStamina += upStamina;
        playerXp.levelUp = false;
        staminaBar.SetMaxStamina(playerStamina.maxStamina);//mise à jour de la barre d'endurance
        levelUpUI.SetActive(false);
    }
    public void UpStrength()
    {
        playerStrength.maxStrength += upStrength;
        playerXp.levelUp = false;
        levelUpUI.SetActive(false);
    }
}
