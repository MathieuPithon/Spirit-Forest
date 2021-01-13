using UnityEngine;

public class PickUpStaminaBuff : MonoBehaviour
{
    public PlayerBuffs playerBuffs;
    public int staminaBuff = 40;
    public float buffTimer = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerBuffs.BuffStamina(staminaBuff, buffTimer);
            Destroy(gameObject);
        }
    }
}
