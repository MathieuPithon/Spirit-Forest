using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRock : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefabs;
    private bool play;
    public bool hurlement;
    public GameObject esprit;
    
    private void Start()
    {
        hurlement=true;
    }

    private void Update() {
        if (hurlement)
        {
            Debug.Log("hurlement");
            onTriggerEnter();
        }
    }

    public void onTriggerEnter()
    {
        Debug.Log("SpawnerRock avant la boucle --> onTriggerEnter");
        
            foreach (var rockPosition in spawnPoints)
            {   
                Debug.Log("Création roche on");
                Instantiate(enemyPrefabs,rockPosition.position,rockPosition.rotation);
                Debug.Log("Fin sleep");
            }
            hurlement = false;
        
        

    }

}
