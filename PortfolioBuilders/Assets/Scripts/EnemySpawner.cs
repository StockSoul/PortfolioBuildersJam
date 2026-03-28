using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // drag your 6 points here

    public GameObject normalEnemy;
    public GameObject shootableEnemy;
    public GameObject scoreTriggerPrefab;  // assign this in the inspector!
    public float speed = 5f; // starting speed of enemies
    public float spawnDelay = 1f;

    private List<GameObject> currentWave = new List<GameObject>(); // track current wave
   

    void Start()
    {
        StartCoroutine(SpawnLoop());//start loop
    }

    IEnumerator SpawnLoop() //loop that can wait
    {
        while (true) //loop forever!
        {
            SpawnWave(); //Spawn enemies

            yield return new WaitForSeconds(spawnDelay); //Wait a few seconds 
            
           speed *= 1.05f; // How fast they gradually go
        }
    }

    void SpawnWave()
    {

        int safeLane = Random.Range(0,spawnPoints.Length); //pick a random safe lane to pick enemy

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject enemyToSpawn;

            if (i == safeLane) //when it gets to safe lane put easy enemy ykkyk
                enemyToSpawn = shootableEnemy;
            else // else u die enemy
                enemyToSpawn = normalEnemy;

            Vector3 spawnPos = spawnPoints[i].position;   //set spawn point

            GameObject enemy = Instantiate(enemyToSpawn,spawnPos,transform.rotation);
    
            // set enemy new speed
             enemy.GetComponent<EnemyScript>().SetSpeed(speed);

             if (i == safeLane)
        {
            Instantiate(scoreTriggerPrefab,spawnPos,transform.rotation);
        }

        }
    }
    
}