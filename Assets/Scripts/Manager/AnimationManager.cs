using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;

    [Header("Status")]
    [SerializeField] private int cardsFinished = 0;
    [SerializeField] private int totalCards = 2;

    public System.Action OnAllAnimationsDone;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void ReportAnimationDone()
    {
        cardsFinished++;

        if (cardsFinished >= totalCards)
        {
            cardsFinished = 0; // reset for next round

            // Invoke callback AFTER both are done
            OnAllAnimationsDone?.Invoke();
        }
    }
}
