using System.Collections;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            Debug.Log("CA TAPE");
        }
    }
}
