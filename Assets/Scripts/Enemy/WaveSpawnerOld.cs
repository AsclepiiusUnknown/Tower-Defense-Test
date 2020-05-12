using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawnerOld : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBtwWaves = 10f;
    private float countdown;
    public float timeBtwSpawns = 0.4f;
    public float startPrepTime = 10f;
    public bool givePrepTime = true;

    public TextMeshProUGUI waveCountdownText;
    public string timerDecimalCount = "F2";

    private int waveIndex = 0;

    public bool useIncrementalTime = true;

    void Start()
    {
        if (givePrepTime)
            countdown = startPrepTime;
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine("SpawnWave");

            if (useIncrementalTime)
            {
                countdown = timeBtwWaves - (timeBtwWaves - waveIndex);
            }
            else
            {
                countdown = timeBtwWaves;
            }
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        //Debug.Log("Wave Incoming!");

        waveIndex++;
        PlayerStats.Waves++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBtwSpawns);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
