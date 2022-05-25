using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRock : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefabs;
    public bool hurlement = false;

    public GameObject esprit;
    
    private void Start()
    {
        hurlement=true;
    }

    private void Update() {
        if (hurlement)
        {
            onTriggerEnter();
        }
    }

    public void onTriggerEnter()
    {
        Debug.Log("SpawnerRock avant la boucle --> onTriggerEnter");
        
            foreach (var rockPosition in spawnPoints)
            {   
                Instantiate(enemyPrefabs,rockPosition.position,rockPosition.rotation);
            }
            hurlement = false;
        
        

    }

}
