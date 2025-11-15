using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerEnemySpawned : MonoBehaviour
{
    public List<GameObject> enemyTypes = new List<GameObject>();

    public GameObject EnemyGetSpawned()
    {
        int randomIndex = Random.Range(0, enemyTypes.Count);

        GameObject enemyType = enemyTypes[randomIndex];
        return enemyType;
    }
}
