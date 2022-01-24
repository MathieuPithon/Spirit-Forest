using UnityEngine;

public class PickUpStaminaRegenBuff : MonoBehaviour
{
    //PlayerBuffs playerBuffs;
    public PlayerBuffs playerBuffs;
    public float staminaRegenBuff = 1f;
    public float regenSpeedBuff = 0.05f;
    public float buffTimer = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //playerBuffs = GameObject.Find("Player").GetComponent<PlayerBuffs>();
            playerBuffs.BuffStaminaRegen(staminaRegenBuff, regenSpeedBuff, buffTimer);
            Destroy(gameObject);
        }
    }
}
