using UnityEngine;

public class PickUpStrengthBuff : MonoBehaviour
{
    public PlayerBuffs playerBuffs;
    public int strengthBuff = 120;
    public float buffTimer = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerBuffs.BuffStrength(strengthBuff, buffTimer);
            Destroy(gameObject);
        }
    }
}
