using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public enum GapTimeMode
    {
        Consecutive,
        ConsecutiveIncremental,
        WaitForEnd,
        WaitIncremental
    }

    [Header("Time Modes & Clamping")]
    public GapTimeMode gapTimeMode;
    public Vector2 CIModeClamp = new Vector2(0, 30);
    public Vector2 WIModeClamp = new Vector2(0, 15);

    [Header("Wait Times & Countdown")]
    public float timeBtwWaves = 5f;
    private float countdown;
    public float startPrepTime = 10f;
    public bool givePrepTime = true;

    [Header("Enemies & Spawning")]
    public static int EnemiesAlive = 0;
    public Transform spawnPoint;
    private int waveIndex = 0;
    public WaveData[] waves;

    [Header("Timer UI")]
    public TextMeshProUGUI waveCountdownText;
    public string timerDecimalCount = "F2";

    void Start()
    {
        if (givePrepTime)
            countdown = startPrepTime;
    }

    void Update()
    {
        if (EnemiesAlive > 0 && (gapTimeMode == GapTimeMode.WaitForEnd || gapTimeMode == GapTimeMode.WaitIncremental))
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine("SpawnWave");

            if (gapTimeMode == GapTimeMode.Consecutive)
            {
                countdown = timeBtwWaves;
            }
            else if (gapTimeMode == GapTimeMode.ConsecutiveIncremental)
            {
                countdown = timeBtwWaves - (timeBtwWaves - waveIndex);
                countdown = Mathf.Clamp(countdown, CIModeClamp.x, CIModeClamp.y);
            }
            else if (gapTimeMode == GapTimeMode.WaitForEnd)
            {
                countdown = timeBtwWaves;
            }
            else if (gapTimeMode == GapTimeMode.WaitIncremental)
            {
                countdown = timeBtwWaves - (timeBtwWaves - waveIndex);
                countdown = Mathf.Clamp(countdown, WIModeClamp.x, WIModeClamp.y);
            }

            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        //Debug.Log("Wave Incoming!");

        PlayerStats.Waves++;

        WaveData wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("Level Won!");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
