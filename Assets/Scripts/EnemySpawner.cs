using UnityEngine;
using System.Collections;
public class EnemySpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    [Header("Wave Settings")]
    public Wave[] waves; // create a wave list in inspector
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;

    private float countdown = 2f;
    private int waveIndex = 0;
    private bool isSpawning = false;

    private void Start()
    {
        EnemiesAlive = 0;
    }
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length) return;

        if (isSpawning) return;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        isSpawning = true;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemyPrefab);

            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        isSpawning = false;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
