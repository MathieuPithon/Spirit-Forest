using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    Permet d'afficher en appuyant sur Tab (non implémenté) pour le moment
**/
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
