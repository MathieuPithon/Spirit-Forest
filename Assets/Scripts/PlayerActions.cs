using System.Collections;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public PlayerHealth playerHealth;
    public PlayerStamina playerStamina;
    public PlayerXp playerXp;
    public PauseMenu pauseMenu;
    
    

    private bool cooldown = false;

    public void Update()
    { 
        if(Input.GetMouseButtonDown(1) && playerStamina.CurrentStamina > 20 && !cooldown)
        {   
            animator.SetTrigger("Attack");
            playerStamina.LoseStamina(20);
            cooldown = true;
            playerXp.XpGain(6);
            StartCoroutine(Cooldown(.5f));
        }
        if (Input.GetButtonDown("powerup") && playerStamina.CurrentStamina > 20 && !cooldown)
        {
            StartCoroutine(Delay());
            playerStamina.LoseStamina(40);
            cooldown = true;
            StartCoroutine(Cooldown(1.5f));
        }
        

    }
    IEnumerator Cooldown(float cool)
    {
        yield return new WaitForSeconds(cool);
        cooldown = false;
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(.5f);
        playerHealth.Healing(20);
    }
}
