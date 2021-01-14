using UnityEngine.UI;
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
    public Text strengthValue;

    public Text upHealthValue;
    public Text upStaminaValue;
    public Text upStrengthValue;
   
    void Update()
    {
        healthValue.text = playerHealth.currentHealth.ToString();
        maxHealthValue.text = playerHealth.maxHealth.ToString();
        staminaValue.text = playerStamina.currentStamina.ToString();
        maxStaminaValue.text = playerStamina.maxStamina.ToString();
        strengthValue.text = playerStrength.strength.ToString();
        

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
                if (playerXp.caracteristicsPoints > 0)
                    levelUpUI.SetActive(true);
                else levelUpUI.SetActive(false);
            }
        }
    }
    public void UpHealth()
    {
        playerHealth.maxHealth += upHealth;
        playerXp.caracteristicsPoints -= 1;
        healthBar.SetMaxHealth(playerHealth.maxHealth); //mise à jour de la barre de vie
        if(playerXp.caracteristicsPoints == 0)
            levelUpUI.SetActive(false);
    }
    public void UpStamina()
    {
        playerStamina.maxStamina += upStamina;
        playerXp.caracteristicsPoints -= 1;
        staminaBar.SetMaxStamina(playerStamina.maxStamina);//mise à jour de la barre d'endurance
        if (playerXp.caracteristicsPoints == 0)
            levelUpUI.SetActive(false);
    }
    public void UpStrength()
    {
        playerStrength.strength += upStrength;
        playerXp.caracteristicsPoints -= 1;
        if (playerXp.caracteristicsPoints == 0)
            levelUpUI.SetActive(false);
    }
}
