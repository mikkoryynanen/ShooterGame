using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnLocation;
    public GameObject enemyPrefab;
    public float spawnRate = 5;

    void Awake()
    {
        ObjectPooler.Add<Enemy>(enemyPrefab);

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        YieldInstruction spawnInstruction = new WaitForSeconds(spawnRate);

        while (true)
        {
            Enemy e = ObjectPooler.Get<Enemy>();
            e.transform.position = spawnLocation.transform.position;

            yield return spawnInstruction;
        }
    }
}
