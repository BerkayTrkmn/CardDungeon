using HelloScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : DungeonObject
{
    protected override void OnEnable()
    {
        base.OnEnable();
    }
    public override void ObjectAction()
    {
        //TODO : NextLevel
    }

    public override IEnumerator CardClicked(Character playerCard)
    {

        yield return playerCard.moveTime.GetWait();
        //TODO: CharacterMove Level ends
        PlayerController.onGameCompleted?.Invoke();

    }
}
