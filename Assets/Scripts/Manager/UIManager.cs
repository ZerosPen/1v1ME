using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Status")]
    [SerializeField] private bool isShowDownCard;

    [Header("References")]
    public GameObject ReadyOrCancelButton;
    public GameObject ShowDownPanel;

    [Header("Events")]
    public HideShowReadyButtonEventSO HideShowReadyButtonEvent;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void HideOrShowDownCard(bool isShow)
    {
        ShowDownPanel.SetActive(isShow);
        isShowDownCard = isShow;
    }

    public void HideOrShowReadyButton(bool isShow)
    {
        ReadyOrCancelButton.SetActive(isShow);
    }

    private void OnEnable()
    {
        HideShowReadyButtonEvent.OnRaiseEvent += HideOrShowReadyButton;
    }

    private void OnDisable()
    {
        HideShowReadyButtonEvent.OnRaiseEvent -= HideOrShowReadyButton;
    }
}
