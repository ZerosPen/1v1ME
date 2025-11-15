using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Change score Event")]
public class ChangeScoreEventSO : ScriptableObject
{
    public UnityAction<int> OnEventRaise;
    
    public void Raise(int score)
    {
        OnEventRaise?.Invoke(score);
    }
}
