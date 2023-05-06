using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Spawnables;

    public void Spawn(int num)
    {
        for (int i = 0; i < num; i++)
            Spawn();
    }

    public void Spawn()
    {
        if (GameManager.Instance.SpawnZombies)
            Instantiate(Spawnables[Random.Range(0, Spawnables.Length)], transform.position, transform.rotation);
    }
}
