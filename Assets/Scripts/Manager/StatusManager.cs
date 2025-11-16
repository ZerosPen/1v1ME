using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public static StatusManager instance;

    [Header("Status Game")]
    [SerializeField] private int _rockUsed;
    [SerializeField] private int _paperUsed;
    [SerializeField] private int _ScissorsUsed;
    [SerializeField] private int _BatKilled;
    [SerializeField] private int _CrowKilled;
    [SerializeField] private int _enemyKilled;

    [Header("Events")]
    //public OnUpdateChangeKilledEnemyEventSO OnUpdateChangeKilledEnemyEvent;
    public OnUpdateUseCardEventSO OnUpdateUseCardEvent;
    public OnChangeCardEventSO OnChangeCardEvent;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateUseCardUI(string cardName, int value)
    {
        Debug.Log($"Get Called {cardName} and {value}");
        
        if (cardName == "rock")
        {
            _rockUsed += value;
            OnUpdateUseCardEvent.Raise(cardName.ToLower(), _rockUsed);
        }
        else if (cardName == "paper")
        {
            _paperUsed += value;
            OnUpdateUseCardEvent.Raise(cardName.ToLower(), _paperUsed);
        }
        else if (cardName == "scissors")
        {
            _ScissorsUsed += value;
            OnUpdateUseCardEvent.Raise(cardName.ToLower(), _ScissorsUsed);
        }
    }

    /*public void UpdateKilledEnemyUI(string enemyName, int value)
    {
        switch (enemyName)
        {
            case "bat":
                _BatKilled += value;
                break;

            case "crow":
                _CrowKilled += value;
                break;

            case "scissors":
                break;
        }
        OnUpdateChangeKilledEnemyEvent.Raise(enemyName.ToLower(), value);
    }*/

    private void OnEnable()
    {
        OnChangeCardEvent.OnRaiseEvent += UpdateUseCardUI;
    }

    private void OnDisable()
    {
        OnChangeCardEvent.OnRaiseEvent -= UpdateUseCardUI;

    }
}
