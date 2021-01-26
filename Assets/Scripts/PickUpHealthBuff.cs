using UnityEngine;

public class PickUpHealthBuff : MonoBehaviour
{
    public PlayerBuffs playerBuffs;
    public int healthBuff = 40;
    public float buffTimer = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {            
            playerBuffs.BuffHealth(healthBuff, buffTimer);
            Destroy(gameObject);
        }
    }
}
