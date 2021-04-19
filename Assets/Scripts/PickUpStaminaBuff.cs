using UnityEngine;

public class PickUpStaminaBuff : MonoBehaviour
{
    PlayerBuffs playerBuffs;
    public int staminaBuff = 40;
    public float buffTimer = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerBuffs = GameObject.Find("Player").GetComponent<PlayerBuffs>();
            playerBuffs.BuffStamina(staminaBuff, buffTimer);
            Destroy(gameObject);
        }
    }
}
