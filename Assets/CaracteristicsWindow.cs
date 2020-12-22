using UnityEngine.UI;
using UnityEngine;

public class CaracteristicsWindow : MonoBehaviour
{
    public GameObject caracteristicsUI;
    public PlayerHealth playerHealth;
    public PlayerStamina playerStamina;
    public PlayerXp playerXp;
    public PlayerCombat playerStrength;
    public PauseMenu pauseMenu;

    public Text healthValue;
    public Text maxHealthValue;
    public Text staminaValue;
    public Text maxStaminaValue;
    public Text xpValue;
    public Text maxXpValue;
    public Text strengthValue;
    public Text maxStrengthValue;

    //pour la force, ajouter dans le take damage ? voir script d'attaque ?

    public bool isOpen = false;
   
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

        if (Input.GetKeyDown(KeyCode.C) && (!PauseMenu.gameIsPaused))
        {
            if (isOpen)
            {
                caracteristicsUI.SetActive(false);
                isOpen = false;
            }
            else
            {
                caracteristicsUI.SetActive(true);
                isOpen = true;
            }

        }
    }

    
}
