using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Change BestScore Event")]
public class ChangeBestScoreEventSO : ScriptableObject
{
    public UnityAction<int> OnEventRaise;

    public void Raise(int bestScore)
    {
        OnEventRaise?.Invoke(bestScore);
    }
}
