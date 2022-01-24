using UnityEngine;

public class PickUpStrengthBuff : MonoBehaviour
{
    //PlayerBuffs playerBuffs;
    public PlayerBuffs playerBuffs;
    public int strengthBuff = 120;
    public float buffTimer = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //playerBuffs = GameObject.Find("Player").GetComponent<PlayerBuffs>();
            playerBuffs.BuffStrength(strengthBuff, buffTimer);
            Destroy(gameObject);
        }
    }
}
