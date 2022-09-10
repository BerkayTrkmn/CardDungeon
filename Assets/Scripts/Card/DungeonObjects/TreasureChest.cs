using HelloScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : DungeonObject , IItemDropper
{
    
    public override void ObjectAction()
    {
    }
    public override IEnumerator CardClicked(Character playerCard)
    {
        yield return 0f.GetWait();
        DropItem(7);
        gameObject.SetActive(false);
        PlayerController.playerState = PlayerState.Play;
    }

    public void DropItem(int cardID)
    {
       Card droppedCard = LevelCreator.instance.cardFactory.NewCardCreateWithID(cardID, x, y);
        droppedCard.gameObject.SetActive(true);
    }
}

internal interface IItemDropper
{

    public void DropItem(int cardID);
}