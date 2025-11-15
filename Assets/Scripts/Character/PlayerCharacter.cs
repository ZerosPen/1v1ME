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
        Debug.Log("DealDamage called with: " + dealDamage);
        target.TakeDamage(dealDamage/2);
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