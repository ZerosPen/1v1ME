using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [Header("Refencesa")]
    public Transform pointPlayerSpawn;
    public Transform pointEnemySpawn;
    public GameObject playerPrefab;
    public RandomizerEnemySpawned randomizerEnemySpawned;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        EnemySpawner();
        PlayerSpwaner();
    }

    public void EnemySpawner()
    {
        GameObject.Instantiate(randomizerEnemySpawned.EnemyGetSpawned(), pointEnemySpawn.position, Quaternion.identity);
    }

    public void PlayerSpwaner()
    {
        GameObject.Instantiate(playerPrefab, pointPlayerSpawn.position, Quaternion.identity);
    }
}
