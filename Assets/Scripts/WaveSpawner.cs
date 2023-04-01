
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform enemyPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float timeBetweenWave = 5f;

    private float countDown = 2f;

    [SerializeField]
    private TextMeshProUGUI waveCounDownTimer;

    private int waveIndex = 0;
    private float currencyRewardMultiplier =1.2f;

    void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWave;
        }
        countDown -= Time.deltaTime;
        waveCounDownTimer.text = Mathf.Round(countDown).ToString();
    }
    IEnumerator SpawnWave()
    {
        Debug.Log("new wave launched");
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

     void SpawnEnemy()
    {
        Transform newEnemy = Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
        newEnemy.GetComponent<Enemy>().currencyReward = Mathf.RoundToInt(newEnemy.GetComponent<Enemy>().currencyReward * Mathf.Pow(currencyRewardMultiplier, waveIndex - 1));
    }
}
