using System.Collections;
using UnityEngine;

public class PlayerBuffs : MonoBehaviour
{   
    public PlayerHealth playerHealth;

    private int healthBuffed;
    private int maxHealthBeforeBuff;   

    public void BuffHealth(int healthBuff, float buffTimer)
    {
        maxHealthBeforeBuff = playerHealth.maxHealth;
        healthBuffed = playerHealth.maxHealth + healthBuff;
        playerHealth.maxHealth = healthBuffed;
        StartCoroutine(HealthBuffTimer(buffTimer));
    }
    public void UnbuffHealth()
    {
        playerHealth.maxHealth = maxHealthBeforeBuff;
    }
    public IEnumerator HealthBuffTimer(float buffTimer)
    {
        yield return new WaitForSeconds(buffTimer);
        UnbuffHealth();
    }
}
