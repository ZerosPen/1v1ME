using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    [Header("Refencese")]
    public TextMeshProUGUI CardRock;
    public TextMeshProUGUI CardPaper;
    public TextMeshProUGUI CardScissors;
    public TextMeshProUGUI EnemyBat;
    public TextMeshProUGUI EnemyCrown;
    public TextMeshProUGUI Enemy;

    [Header("Events")]
    //public OnUpdateChangeKilledEnemyEventSO OnUpdateChangeKilledEnemyEvent;
    public OnUpdateUseCardEventSO OnUpdateUseCardEvent;

    public void UpdateUseCardUI(string cardName, int value)
    {
        switch (cardName)
        {
            case "rock":
                CardRock.text = value.ToString();
                break;

            case "paper":
                CardPaper.text = value.ToString();
                break;

            case "scissors":
                CardScissors.text = value.ToString();
                break;
        }
    }

    /*public void UpdateKilledEnemyUI(string enemyName, int value)
    {
        switch (enemyName)
        {
            case "bat":
                CardRock.text = value.ToString();
                break;

            case "crow":
                CardPaper.text = value.ToString();
                break;

            case "scissors":
                break;
        }
    }*/

    private void OnEnable()
    {
        //OnUpdateChangeKilledEnemyEvent.OnRaiseEvent += UpdateKilledEnemyUI;
        OnUpdateUseCardEvent.OnRaiseEvent += UpdateUseCardUI;
    }

    private void OnDisable()
    {
       //OnUpdateChangeKilledEnemyEvent.OnRaiseEvent -= UpdateKilledEnemyUI;
        OnUpdateUseCardEvent.OnRaiseEvent -= UpdateUseCardUI;
    }
}
