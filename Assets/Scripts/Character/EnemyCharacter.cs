using UnityEngine;
using UnityEngine.UI;

public class EnemyCharacter : Character
{
    [SerializeField] private CharacterSO characterdata;

    [Header("References")]
    [SerializeField] private Image healthBar;
    [SerializeField] private SpriteRenderer _characterSprite;
    [SerializeField] private HealtPointUI _healPointUI;
    [SerializeField] private CurrentEnemyHandler currentEnemyHandler;
    

    [Header("Event")]
    public OnKillEnemyEventSO OnKillEnemyEvent;

    private void Start()
    {
        maxHealtPoint = characterdata.healtPointCharacter;
        nameCharacter = characterdata.nameCharacter;
        healtPoints   = characterdata.healtPointCharacter;
        dealDamage    = characterdata.dealDamageCharacter;
        //_characterSprite.sprite = characterdata.spriteCharacter;

        SetCurrentEnemy();
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
        if (currentEnemyHandler == null)
        {
            SetCurrentEnemy();
        }
        else
        {
            currentEnemyHandler.SetEnemyKillEventChannel();
            Destroy(gameObject);
        }
    }

    private void SetCurrentEnemy()
    {
        if (currentEnemyHandler == null)
        {
            currentEnemyHandler = GameObject.FindGameObjectWithTag("EventEnemyHandler")
                                            .GetComponent<CurrentEnemyHandler>();
        }
        currentEnemyHandler.SetEnemy(this);
        
        if (GetIsDeadCharacter())
        {
            OnDeath();
        }
    }
}
