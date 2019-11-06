using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] EnemyTypePrefabs;

    public SpawnWave[] SpawnWaves;
    public SpawnWaveRecurring[] RecurringWaves;

    Transform _t;

    private void Awake()
    {
        _t = GetComponent<Transform>();
        if(EnemyTypePrefabs.Length == 0)
        {
            Debug.LogWarning("No enemy types set up for " + name + "! Disabling spawner.");
            enabled = false;
        }
    }

    void Update()
    {
        for(int i = 0; i < SpawnWaves.Length; i++)
        {            
            if (Time.time > SpawnWaves[i].When && !SpawnWaves[i].Spawned)
            {
                DoSpawnWave(ref SpawnWaves[i]);
            }
        }

        for (int i = 0; i < RecurringWaves.Length; i++)
        {
            SpawnWaveRecurring w = RecurringWaves[i];
            if(Time.time > w.FirstWaveAt && Time.time - w.LastSpawn > w.WaveInterval)
            {
                DoRecurringWave(ref RecurringWaves[i]);
            }
        }
    }

    void DoSpawnWave(ref SpawnWave wave)
    {
        wave.Spawned = true;
        SpawnEnemies(wave.EnemyTypeIndex, wave.EnemyCount);
    }

    void DoRecurringWave(ref SpawnWaveRecurring wave)
    {
        wave.LastSpawn = Time.time;
        int count = wave.EnemyCount;
        if (wave.AllowRandomizedCount)
        {
            count += Random.Range(-count / 2, count / 2);
        }
        SpawnEnemies(wave.EnemyTypeIndex, count);
    }

    void SpawnEnemies(int EnemyTypeIndex, int count)
    {
        float maxY = Camera.main.ViewportToWorldPoint(Vector3.up).y;
        float minY = Camera.main.ViewportToWorldPoint(Vector3.zero).y;

        for (int i = 0; i < count; i++)
        {
            if (EnemyTypeIndex < EnemyTypePrefabs.Length && EnemyTypeIndex >= 0)
            {
                Vector3 spawnPos = _t.position;
                spawnPos.y = Random.Range(minY, maxY);
                spawnPos.x += Random.Range(-1.0f, 1.0f);
                Enemy e = Instantiate<Enemy>(EnemyTypePrefabs[EnemyTypeIndex], spawnPos, _t.rotation);
            }
        }

    }
}

[System.Serializable]
public struct SpawnWave
{
    public int EnemyTypeIndex;
    public int EnemyCount;
    public float When;
    public bool Spawned;
}

[System.Serializable]
public struct SpawnWaveRecurring
{
    public int EnemyTypeIndex;
    public int EnemyCount;
    public bool AllowRandomizedCount;
    public float FirstWaveAt;
    public float WaveInterval;
    public float LastSpawn;
}
