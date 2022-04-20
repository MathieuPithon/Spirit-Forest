using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point_light : MonoBehaviour
{

    Light firelight;
    float lightInt;
    public float minInt = 3f, maxInt = 5f;
    // Start is called before the first frame update
    void Start(){
        firelight = GetComponent<Light> ();
    }

    // Update is called once per frame
    void Update(){
        lightInt = Random.Range (minInt, maxInt);
        firelight.intensity = lightInt;
    }
}
