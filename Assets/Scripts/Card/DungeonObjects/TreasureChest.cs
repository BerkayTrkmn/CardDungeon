using HelloScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : DungeonObject
{
    
    public override void ObjectAction()
    {
    }
    public override IEnumerator CardClicked(Character playerCard)
    {
        yield return 0.3f.GetWait();
    }
}