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
    
    private void Update() {
        Debug.Log("Up");
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
        
        

    }

}
