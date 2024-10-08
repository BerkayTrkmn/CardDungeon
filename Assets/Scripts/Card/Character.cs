using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using HelloScripts;
using System.Reflection;
using DG.Tweening;
public abstract class Character : Card
{

    public int health;
    public int attack;
    public int sight;
    public float moveTime = 0.5f;
    protected TextMeshPro attackText;
    protected TextMeshPro healthText;
    public static Action onCharacterAttack;
    public static Action onEnemyKilled;
    public bool isDead = false;
    public Type cardType;
    protected SpriteRenderer cardSprite;
    protected Animator cardAnimator;
    protected override void OnEnable()
    {
        base.OnEnable();
        characterStatsParent.gameObject.SetActive(true);
        healthText = characterStatsParent.GetChild(0).GetChild(0).GetComponent<TextMeshPro>();
        attackText = characterStatsParent.GetChild(1).GetChild(0).GetComponent<TextMeshPro>();
        GetCardSprite();
        GetCardAnimator();
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

    #region Setters/Getters
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
    public virtual SpriteRenderer GetCardSprite()
    {
        return cardSprite = transform.GetChild(3).GetChild(0).GetComponent<SpriteRenderer>();
    }
    public virtual void GetCardAnimator()
    {
        cardAnimator = cardSprite.GetComponent<Animator>();
    }
    #endregion

    public void CharacterAttack(Character character)
    {
        character.health -= attack;
        if (character.health < 0) character.health = 0;
        if (health > 0) { 
            cardAnimator.SetTrigger(Config.ANIM_ATTACK);
        
        }
        character.SetHealthText(character.healthText);
        onCharacterAttack?.Invoke();
    }
   
    public bool IsCharacterDead()
    {
        return health <= 0 ? true : false;
    }
    public override IEnumerator CardClicked(Character playerCard)
    {
        if (health > 0)
        {
            playerCard.CharacterAttack(this);

            yield return new WaitForSeconds(cardAnimator.GetCurrentAnimatorStateInfo(0).length);
            if (!IsCharacterDead())
                CharacterAttack(playerCard);
            else
            {
                //TODO : player haraket edebilir.
                cardAnimator.GetComponent<AnimationFunctions>().SetDeathAction(CharacterDeath);
                cardAnimator.SetTrigger(Config.ANIM_DEAD);
            }
            if (playerCard.IsCharacterDead())
            {
                PlayerController.onGameFailed?.Invoke();

            }
            PlayerController.playerState = PlayerState.Play;
        }
        else
        {

            playerCard.MoveCard(this);
            gameObject.SetActive(false);
        }

    }
    public virtual void MoveCard(Card moveToCard, TweenCallback onComplete)
    {
        transform.DOMove(moveToCard.transform.position, 0.5f).OnComplete(onComplete);

    }
    public virtual void MoveCard(Card moveToCard)
    {
        LevelCreator lc = LevelCreator.instance;
        lc.mainCamera.transform.DOMove(moveToCard.transform.position + Vector3.back, 0.5f);
        //lc.CloseAllLevelCards();
        transform.DOMove(moveToCard.transform.position, 0.5f).OnComplete(() =>
        {
            LevelCreator.levelCards[x, y] = lc.cardFactory.NewCardCreateWithPrefab(lc.cardFactory.prefabList[0], lc.cardFactory.cardsData[0], x, y);
            x = moveToCard.x;
            y = moveToCard.y;
            LevelCreator.levelCards[x, y] = this;

            lc.SetPlayerSightedCards(this);
            PlayerController.playerState = PlayerState.Play;
        });



    }
    public virtual void CharacterDeath()
    {
        characterGO.Destroy();
        attackText.gameObject.SetActive(false);
        healthText.gameObject.SetActive(false);
        isDead = true;
        onEnemyKilled?.Invoke();
    }
}
