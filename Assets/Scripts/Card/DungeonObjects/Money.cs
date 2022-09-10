using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelloScripts;
public class Money : DungeonObject
{
    [SerializeField] private int minMoney = 5;
    [SerializeField] private int maxMoney = 15;
    public override void ObjectAction()
    {
    }

    public override IEnumerator CardClicked(Character playerCard)
    {

        gameObject.SetActive(false);
        yield return 0f.GetWait();
        playerCard.MoveCard(this);
        PlayerController.money += GetMoneyCount();
        PlayerController.onMoneyGain.Invoke();
    }

    private int  GetMoneyCount()
    {
        return Random.Range(minMoney, maxMoney + 1);
    }
}
