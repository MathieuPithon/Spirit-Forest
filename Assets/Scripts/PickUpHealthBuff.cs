using UnityEngine;

public class PickUpHealthBuff : MonoBehaviour
{
    PlayerBuffs playerBuffs;
    public int healthBuff = 40;
    public float buffTimer = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerBuffs = GameObject.Find("Player").GetComponent<PlayerBuffs>();
            playerBuffs.BuffHealth(healthBuff, buffTimer);
            Destroy(gameObject);
        }
    }
}
