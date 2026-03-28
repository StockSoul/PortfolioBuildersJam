using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // drag your 6 points here

    public GameObject normalEnemy;
    public GameObject shootableEnemy;

    public float spawnDelay = 2f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnWave();

            yield return new WaitForSeconds(spawnDelay);

            // makes game harder over time
            spawnDelay = Mathf.Max(0.5f, spawnDelay - 0.05f);
        }
    }

    void SpawnWave()
    {
        int safeLane = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject enemyToSpawn;

            if (i == safeLane)
                enemyToSpawn = shootableEnemy;
            else
                enemyToSpawn = normalEnemy;

            Vector3 spawnPos = spawnPoints[i].position;

            // optional: spawn slightly off screen to the right
            spawnPos += new Vector3(10f, 0f, 0f);

            Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
        }
    }
}