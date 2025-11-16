using UnityEngine;
using TMPro;

public class scoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    public ChangeBestScoreEventSO bestScoreEvent;
    public ChangeScoreEventSO changeScoreEvent;

    public void StartScore(int bestScore)
    {
        scoreText.text = "Score : " + 0.ToString("D5");
        bestScoreText.text = "BestScore : " + bestScore.ToString("D5");
    }

    public void UpdateScore(int score, int bestScore)
    {
        scoreText.text = "Score : " + score.ToString();
        if (score > bestScore)
        {
            bestScoreText.text = "BestScore : " + bestScore.ToString("D5");
        }
        
    }

    private void OnEnable()
    {
        bestScoreEvent.OnEventRaise += StartScore;
        changeScoreEvent.OnEventRaise += UpdateScore;
    }

    private void OnDisable()
    {
        bestScoreEvent.OnEventRaise -= StartScore;
        changeScoreEvent.OnEventRaise -= UpdateScore;
    }
}
