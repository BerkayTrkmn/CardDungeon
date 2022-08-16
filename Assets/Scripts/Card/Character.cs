using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using HelloScripts;

public abstract class Character : Card
{

    public int health;
    public int attack;
    public int sight;
    public float moveTime = 0.5f;
    protected TextMeshPro attackText;
    protected TextMeshPro healthText;
    public static Action onCharacterAttack;

    protected override void OnEnable()
    {
        base.OnEnable();
        characterStatsParent.gameObject.SetActive(true);
        healthText = characterStatsParent.GetChild(0).GetChild(0).GetComponent<TextMeshPro>();
        attackText = characterStatsParent.GetChild(1).GetChild(0).GetComponent<TextMeshPro>();
    }
    public override void SetCard(CardData cardData, int _x, int _y)
    {
        base.SetCard(cardData, _x, _y);
        CharacterCardData data = ((CharacterCardData)cardData);

        health = data.health;
        attack = data.attack;
        sight = data.sight;
        SetCharacterText(attackText, healthText);
    }

    public void SetCharacterText(TextMeshPro attackText, TextMeshPro healthText)
    {
        SetAttackText(attackText);
        SetHealthText(healthText);
    }
    public void SetAttackText(TextMeshPro attackText)
    {
        attackText.text = attack.ToString();
    }
    public void SetHealthText(TextMeshPro healthText)
    {
        healthText.text = health.ToString();
    }
    public void CharacterAttack(Character character)
    {
        character.health -= attack;
        if (character.health < 0) character.health = 0;
        character.SetHealthText(character.healthText);
        onCharacterAttack?.Invoke();
    }
    public bool IsCharacterDead()
    {
        return health <= 0 ? true : false; 
    }
    public override IEnumerator CardClicked(Character playerCard)
    {
        if (health != 0)
        {


            playerCard.CharacterAttack(this);
            yield return new WaitForSeconds(0.3f);
            if (!IsCharacterDead())
                CharacterAttack(playerCard);
            else
            {
                //TODO : player haraket edebilir.
                characterGO.Destroy();

            }
            if (playerCard.IsCharacterDead())
            {
                PlayerController.onGameFailed?.Invoke();

            }
        }
    }
    
}
