using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHub : MonoBehaviour
{
    [SerializeField] EnemySpawner[] Spawners;
    [SerializeField, Tooltip("The duration between spawner triggers"), Range(1, 10)] float MinSpawnTime = 1;
    [SerializeField, Tooltip("The duration between spawner triggers"), Range(1, 10)] float MaxSpawnTime = 10;

    [SerializeField, Tooltip("The number of Zombies spawned when spawners are triggered"), Range(1, 5)] int MinSpawned = 1;
    [SerializeField, Tooltip("The number of Zombies spawned when spawners are triggered"), Range(1, 5)] int MaxSpawned = 3;

    [SerializeField, Tooltip("How much the players score effects the spawn rates and spawn numbers")] float ScoreEvolutionRate = .02f;

    [SerializeField] int OnStartSpawnTimes = 10;

    private float Timer = 0;

    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0 && GameManager.Instance.SpawnZombies)
        {
            Spawners[Random.Range(0, Spawners.Length)].Spawn(GetNumSpawned());
            Timer = GetCooldown();
        }
    }

    private int GetNumSpawned()
    {
        int numSpawned = Random.Range(MinSpawned, MaxSpawned + 1);
        GameManager.Instance.UpdateTotalZombies(numSpawned);
        return numSpawned;
    }
    private float GetCooldown()
    {
        //Debug.Log($"Base: Min {MinSpawnTime}, Max {MaxSpawnTime}");
        //Debug.Log($"Edit: Min {MinSpawnTime + ((GameManager.Instance.Score * ScoreEvolutionRate) / 3)}, Max {MaxSpawnTime - ((GameManager.Instance.Score * ScoreEvolutionRate) / 2)}");
        //float ret = Random.Range(MinSpawnTime + ((GameManager.Instance.Score * ScoreEvolutionRate) / 3), MaxSpawnTime - ((GameManager.Instance.Score * ScoreEvolutionRate) / 2));
        //Debug.Log($"Random: {ret}");
        //return ret; 
        return Random.Range(MinSpawnTime + ((GameManager.Instance.Score * ScoreEvolutionRate) / 3), MaxSpawnTime - ((GameManager.Instance.Score * ScoreEvolutionRate) / 2));
    }
}
