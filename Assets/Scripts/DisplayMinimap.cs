using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMinimap : MonoBehaviour
{
    public GameObject minimapCanvas;


    // Start is called before the first frame update
    void Start()
    {
        minimapCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            minimapCanvas.SetActive(true);
        }
        else
        {
            minimapCanvas.SetActive(false);
        }

    }
}
