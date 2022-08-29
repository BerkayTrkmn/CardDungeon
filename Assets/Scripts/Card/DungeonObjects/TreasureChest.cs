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
        yield return 0.3f.GetWait();
    }

    public void DropItem(DungeonObject dungeonObject)
    {
        throw new System.NotImplementedException();
    }
}

internal interface IItemDropper
{

    public void DropItem(DungeonObject dungeonObject);
}