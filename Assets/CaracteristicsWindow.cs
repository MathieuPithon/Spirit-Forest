using UnityEngine.UI;
using UnityEngine;

public class CaracteristicsWindow : MonoBehaviour
{
    public GameObject caracteristicsUI;
    public PlayerHealth playerHealth;
    public PlayerStamina playerStamina;
    public PlayerXp playerXp;
    public PauseMenu pauseMenu;

    public Text healthValue;
    public Text maxHealthValue;
    public Text staminaValue;
    public Text maxStaminaValue;
    public Text xpValue;
    public Text maxXpValue;

    //pour la force, ajouter dans le take damage ? voir script d'attaque ?

    public bool isOpen = false;
   
    void Update()
    {
        healthValue.text = playerHealth.currentHealth.ToString();
        maxHealthValue.text = playerHealth.maxHealth.ToString();
        staminaValue.text = playerStamina.currentStamina.ToString();
        maxStaminaValue.text = playerStamina.maxStamina.ToString();
        xpValue.text = playerXp.currentXp.ToString();
        maxXpValue.text = "?";

        if(Input.GetKeyDown(KeyCode.C) && (!PauseMenu.gameIsPaused))
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
