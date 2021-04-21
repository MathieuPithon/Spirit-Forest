using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
        if (collision.transform.CompareTag("Player"))
        {
            PlayerCombat playerCombat = GameObject.Find("Player").GetComponent<PlayerCombat>();
            if (playerCombat.paradeActive == false)
            {
                attackPlacement = false;
                playerHealth.TakeDamage(damageOnCollision, attackPlacement);
                damagedPlayer = true;
            }
        }
    }
    public IEnumerator PlayerDamagedTimer()
    {
        yield return new WaitForSeconds(playerDamagedTimer);
        damagedPlayer = false;
    }
}
