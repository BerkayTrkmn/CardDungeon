using DG.Tweening;
using HelloScripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class DungeonObject : Card
{
    public abstract void ObjectAction();

    protected override void OnEnable()
    {
        base.OnEnable();

    }
    public override void SetCard(CardData cardData, int _x, int _y)
    {
        base.SetCard(cardData, _x, _y);
        ShowName();
    }
    protected void ShowName()
    {
        Debug.Log(cardName);
        TextMeshPro nameText = nameShowerParent.GetChild(0).GetComponent<TextMeshPro>();

        nameText.text = cardName.ToUpperInvariant();
        nameShowerParent.gameObject.SetActive(true);
    }
    public override IEnumerator CardClicked(Character playerCard)
    {
        gameObject.SetActive(false);
        yield return 0f.GetWait();
        playerCard.MoveCard(this);
    }
    //public void ChangeThisCardWithMoney(Card card)
    //{

    //}
}


