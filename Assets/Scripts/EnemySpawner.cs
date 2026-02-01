using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;

    [Header("Night Settings")]
    [SerializeField] float spawnInterval = 5f;

    int enemiesToSpawnThisNight;
    int spawnedThisNight;

    bool spawningActive = false;

    void OnEnable()
    {
        NightManager.OnNightStarted += StartSpawning;
        NightManager.OnDayStarted += StopSpawning;
    }

    void OnDisable()
    {
        NightManager.OnNightStarted -= StartSpawning;
        NightManager.OnDayStarted -= StopSpawning;
    }

    void StartSpawning(int day)
    {
        spawningActive = true;

        enemiesToSpawnThisNight = 5 + day * 2;
        spawnedThisNight = 0;

        spawnInterval = Mathf.Max(1f, 5f - day * 0.3f);

        StartCoroutine(SpawnLoop());
    }

    void StopSpawning(int day)
    {
        spawningActive = false;
    }

    IEnumerator SpawnLoop()
    {
        while (spawningActive)
        {
            if (spawnedThisNight >= enemiesToSpawnThisNight)
                yield break;

            SpawnEnemy();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
            return;

        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject enemy = Instantiate(enemyPrefab, point.position, Quaternion.identity);

        var enemyBeh = enemy.GetComponent<EnemyBehaviour>();

        NightManager.Instance.RegisterNightEnemy(enemyBeh);

        spawnedThisNight++;
    }
}
