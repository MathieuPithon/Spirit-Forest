using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    Wikipédia : 
        La parallaxe est l’impact d'un changement d'incidence d'observation, 
    c'est-à-dire du changement de position de l'observateur, sur l'observation d'un objet. 
    La parallaxe est l'effet du changement de position de l'observateur sur ce qu'il perçoit.

    En des mots plus simples, la parallaxe est le fait qu'on perçoit différemment les objets plus loin que ceux qu'ils sont proches. 
    Ils défilent plus lentement que ceux qui sont proches (comme en voiture). 

    Cette classe mets en place ce mécanisme. 
**/

public class Parallaxing : MonoBehaviour
{
    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smoothing = 1f;

    public Transform cam;
    private Vector3 previousCamPos;

    private void Awake()
    {
        cam = Camera.main.transform;
    }
    void Start()
    {
        previousCamPos = cam.position;
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
                    
        }
        previousCamPos = cam.position;

    }
}
