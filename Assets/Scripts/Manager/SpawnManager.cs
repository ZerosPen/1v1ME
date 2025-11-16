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

    [Header("Events")]
    public OnKillEnemyEventSO OnKillEnemyEvent;

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

    private void OnEnable()
    {
        OnKillEnemyEvent.OnRaiseEvent += EnemySpawner;
    }

    private void OnDisable()
    {
        OnKillEnemyEvent.OnRaiseEvent -= EnemySpawner;
    }
}
