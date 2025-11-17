using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("Score Status")]
    [SerializeField] private int score;
    [SerializeField] private int _bestScore;

    [Header("Events")]
    public ChangeScoreEventSO changeScoreEvent;
    public ChangeBestScoreEventSO bestBestScoreEvent;
    public OnShowLosePanelEventSO onShowLosePanelEvent;


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
        CallToLoadBestScore();
    }

    public void InitializeScoreUI(int bestScore)
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
        changeScoreEvent.Raise(score, _bestScore);
    }

    public void Save(ref BestScoreSaveData data)
    {
        if (score > _bestScore)
            data.bestScore = score;

        Debug.Log("Save score : " + score);
    }

    public void Load(BestScoreSaveData data)
    {
        _bestScore = data.bestScore;
        Debug.Log("Load score : " + _bestScore);
        InitializeScoreUI(_bestScore);
    }

    private void CallToSaveBestScore()
    {
        SaveSystem.Save();
    }

    private void CallToLoadBestScore()
    {
        SaveSystem.Load();
    }

    private void OnEnable()
    {
        onShowLosePanelEvent.OnRaiseEvent += CallToSaveBestScore;
    }

    private void OnDisable()
    {
        onShowLosePanelEvent.OnRaiseEvent -= CallToSaveBestScore;
    }
}

[System.Serializable]
public struct BestScoreSaveData
{
    public int bestScore;
}
