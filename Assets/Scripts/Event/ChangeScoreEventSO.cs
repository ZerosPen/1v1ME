using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Change score Event")]
public class ChangeScoreEventSO : ScriptableObject
{
    public UnityAction<int, int> OnEventRaise;
    
    public void Raise(int score, int bestScore)
    {
        OnEventRaise?.Invoke(score, bestScore);
    }
}
