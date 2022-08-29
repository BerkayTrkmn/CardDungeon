using DG.Tweening;
using HelloScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : DungeonObject
{
    public override IEnumerator CardClicked(Character playerCard)
    {
        gameObject.SetActive(false);
        yield return 0f.GetWait();
        playerCard.MoveCard(this);
    }
   
    public override void ObjectAction()
    {
    }

}
