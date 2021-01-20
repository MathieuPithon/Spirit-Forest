using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffects : MonoBehaviour
{
    public GameObject castPrefab;
    public float speed = 2;
    
    public void CastKatanaEffect()
    {
        castPrefab.GetComponent<SpriteRenderer>().enabled = true;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Debug.Log("Dessiné !");
        
    }
    public void UnCastKatanaEffect()
    {
        castPrefab.GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Effacé");
    }
}
