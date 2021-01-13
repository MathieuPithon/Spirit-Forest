using UnityEngine;

public class PickUpSpeedBuff : MonoBehaviour
{
    public PlayerBuffs playerBuffs;
    public float speedBuff = 120;
    public float buffTimer = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerBuffs.BuffSpeed(speedBuff, buffTimer);
            Destroy(gameObject);
        }
    }
}
