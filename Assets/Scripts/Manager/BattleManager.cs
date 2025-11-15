using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    [SerializeField] private int killedEnemy;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnkilledEnemy()
    {
        killedEnemy++;
        ScoreManager.instance.AddScore(100);
    }
}
