using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("status")]
    [SerializeField] private bool _canPickUpCard;
    [SerializeField] private bool isSelected;

    [Header("Scale Settings")]
    public float normalScale = 1f;
    public float hoverScale = 1.05f;
    public float smallScale = 0.9f;

    [Header("Position Settings")]
    public float normalPosY = -105f;
    public float selectedPosY = -100f;
    public float tweenTime = 0.15f;

    [Header("Events")]
    public CanPickUpCardEventSO canPickUpCardEvent;
    public HoverCardButtonEventSO hoverCardButtonEvent;
    public ExitCardButtonEventSO exitCardButtonEvent;
    public SelectedCardButtonEventSO selectedCardButtonEvent;
    public UnityEvent OnClick;
    
    private RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isSelected && _canPickUpCard)
        {
            if (!isSelected)
                rect.DOScale(hoverScale, tweenTime).SetEase(Ease.OutBack);
        }
        hoverCardButtonEvent.Raise(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isSelected && _canPickUpCard)
            rect.DOScale(normalScale, tweenTime).SetEase(Ease.OutBack);

        exitCardButtonEvent.Raise(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Select();
        selectedCardButtonEvent.Raise(this);
    }

    public void Select()
    {
        isSelected = true;
        rect.DOScale(hoverScale, tweenTime);
        rect.DOAnchorPosY(selectedPosY, tweenTime);
        OnClick.Invoke();
    }

    public void Deselect()
    {
        isSelected = false;
        rect.DOScale(normalScale, tweenTime);
        rect.DOAnchorPosY(normalPosY, tweenTime);
    }

    public void Shrink()
    {
        if (!isSelected)
            rect.DOScale(smallScale, tweenTime);
    }

    public bool GetIsSeleted()
    {
        return isSelected;
    }

    public void ResetSize()
    {
        if (!isSelected)
            rect.DOScale(normalScale, tweenTime);
    }

    void SetCanPickUpCard(bool canPickUp)
    {
        _canPickUpCard = canPickUp;
        if (_canPickUpCard == true)
            Deselect();
    }

    private void OnEnable()
    {
        canPickUpCardEvent.OnRaiseEvent += SetCanPickUpCard;
    }
    private void OnDisable()
    {
        canPickUpCardEvent.OnRaiseEvent -= SetCanPickUpCard;
    }
}
