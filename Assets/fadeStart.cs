using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeStart : MonoBehaviour
{
    public GameObject img;
    // Start is called before the first frame update
    void Start()
    {
        img.SetActive(true);
    }
}
