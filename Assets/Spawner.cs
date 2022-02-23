using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    private bool play;

    void Start()
    {
        StartCoroutine(myWaitCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

        if(!play){
            StartCoroutine(myWaitCoroutine());
        }

        /*if(Input.GetMouseButtonDown(0))
        {
            
        }    */
    }
    IEnumerator myWaitCoroutine()
    {
        
        play= true;
        yield return new WaitForSeconds(0.8f);// Wait for one second

        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, transform.rotation);
        play=false;
    }

}

