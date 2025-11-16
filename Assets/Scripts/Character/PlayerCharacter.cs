using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : Character
{
    [SerializeField] private CharacterSO characterdata;

    [Header("References")]
    [SerializeField] private Image healthBar;
    [SerializeField] private SpriteRenderer _characterSprite;
    [SerializeField] private HealtPointUI _healPointUI;
    [SerializeField] private CurrentPlayerHandler currentPlayerHandler;

    [Header("Events")]
    public SetPlayerCardEventSO setPlayerCardEvent;

    private void Start()
    {
        maxHealtPoint = characterdata.healtPointCharacter;
        nameCharacter = characterdata.nameCharacter;
        healtPoints   = characterdata.healtPointCharacter;
        dealDamage    = characterdata.dealDamageCharacter;
        //_characterSprite.sprite = characterdata.spriteCharacter;

        SetCurrentPlayer();
    }

    private void Update()
    {
        healthBar.fillAmount = healtPoints / maxHealtPoint;
        _healPointUI.UpdateHealtPoints(healtPoints, maxHealtPoint);
    }

    public override void DealDamage(Character target)
    {
        Debug.Log($"{nameCharacter} is dealing {dealDamage} damage to {target.nameCharacter}");
        target.TakeDamage(dealDamage);
    }

    public override void OnDeath()
    {
        
    }

    private void SetCurrentPlayer()
    {
        if (currentPlayerHandler == null)
        {
            currentPlayerHandler = GameObject.FindGameObjectWithTag("EventPLayerHandler")
                                             .GetComponent<CurrentPlayerHandler>();  
        }
        currentPlayerHandler.SetPlayer(this);
    }
}