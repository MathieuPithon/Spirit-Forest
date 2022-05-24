using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    private bool play;
    public GameObject esprit;
    void Start()
    {
        StartCoroutine(myWaitCoroutine());
        esprit.GetComponent<Animator>().SetTrigger("EndClimb");
        Debug.Log("Spawner.cs");
         
    }

    // Update is called once per frame
    void Update()
    {

        if(!play){
            StartCoroutine(myWaitCoroutine());
        }

    }
    IEnumerator myWaitCoroutine()
    {
        Debug.Log("Spawner.cs");
        play= true;
        yield return new WaitForSeconds(0.8f);// Wait for 0.8 second

        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, transform.rotation);
        play=false;
    }

}

