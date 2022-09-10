using HelloScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        gameObject.SetActive(false);
        yield return 0f.GetWait();
        playerCard.MoveCard(this);
        PlayerController.onGameCompleted?.Invoke();

    }
}
