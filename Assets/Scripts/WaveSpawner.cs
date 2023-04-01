
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    //[SerializeField]
    //private Transform enemyPrefab;

    //[SerializeField]
    //private Transform spawnPoint;

    //[SerializeField]
    //private float timeBetweenWave = 5f;

    //private float countDown = 2f;

    //[SerializeField]
    //private TextMeshProUGUI waveCounDownTimer;

    //private int waveIndex = 0;
    //private float currencyRewardMultiplier =1.2f;

    //void Update()
    //{
    //    if (countDown <= 0f)
    //    {
    //        StartCoroutine(SpawnWave());
    //        countDown = timeBetweenWave;
    //    }
    //    countDown -= Time.deltaTime;
    //    waveCounDownTimer.text = Mathf.Round(countDown).ToString();
    //}
    //IEnumerator SpawnWave()
    //{
    //    Debug.Log("new wave launched");
    //    waveIndex++;

    //    for (int i = 0; i < waveIndex; i++)
    //    {
    //        SpawnEnemy();
    //        yield return new WaitForSeconds(0.5f);
    //    }
    //}

    // void SpawnEnemy()
    //{
    //    Transform newEnemy = Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    //    newEnemy.GetComponent<Enemy>().currencyReward = Mathf.RoundToInt(newEnemy.GetComponent<Enemy>().currencyReward * Mathf.Pow(currencyRewardMultiplier, waveIndex - 1));
    //}


    public GameObject enemyPrefab; // The prefab of the enemy to spawn
    public Transform[] spawnPoints; // The positions where enemies will spawn
    public float spawnInterval = 1f; // The time between each enemy spawn
    public int maxEnemies = 10; // The maximum number of enemies that can be alive at once

    private int numEnemies;

    private void Start()
    {
        numEnemies = 0;
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (numEnemies < maxEnemies)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Get the Path component for the spawn point
        SpawnPoint spawn = spawnPoint.GetComponent<SpawnPoint>();

        // Spawn the enemy at the spawn point with the specified path
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemy.GetComponent<Enemy>().SetPath(spawn.spawnpath); // Set the path for the enemy

        // Increase the number of enemies
        numEnemies++;

        // Set up an event to be triggered when the enemy dies
        enemy.GetComponent<Enemy>().OnDeath += () =>
        {
            numEnemies--;
        };
    }

}
