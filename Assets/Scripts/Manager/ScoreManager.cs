using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("Score Status")]
    [SerializeField] private int score;
    [SerializeField] private int bestScore;

    public ChangeScoreEventSO changeScoreEvent;
    public ChangeBestScoreEventSO bestBestScoreEvent;

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
        InitializeScoreUI();
    }

    public void InitializeScoreUI()
    {
        changeScoreEvent.Raise(score, bestScore);
        bestBestScoreEvent.Raise(bestScore);
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        changeScoreEvent.Raise(score, bestScore);
    }
}
