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
        ObjectPooler.Add("enemy", enemyPrefab);

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        YieldInstruction spawnInstruction = new WaitForSeconds(spawnRate);

        while (true)
        {
            GameObject go = ObjectPooler.Get("enemy");
            go.transform.localRotation = go.transform.localRotation;
            yield return spawnInstruction;
        }
    }
}
