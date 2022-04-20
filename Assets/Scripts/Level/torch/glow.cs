using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glow : MonoBehaviour
{
    Renderer rend;
    float colInt;
    Color c;
    public float minColInt = 0.5f, maxCalInt = 1f;
    // Start is called before the first frame update
    void Start(){
        rend = GetComponent<SpriteRenderer> ();
    }
    // Update is called once per frame
    void Update(){
        colInt = Random.Range (minColInt, maxCalInt);
        c = rend.material.color;
        c.a = colInt;
        rend.material.color = c;
    }
}
