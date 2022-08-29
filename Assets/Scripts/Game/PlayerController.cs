using HelloScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Character playerCard;
    public static Action onGameStarted;
    public static Action onGameFailed;
    public static Action onGameCompleted;
   public static PlayerState playerState = PlayerState.Play;
    public static int money= 0;
    LevelCreator lc;
    private void OnEnable()
    {
        TouchManager.Instance.onTouchBegan += OnTouchBegan;
        onGameFailed -= OnGameFailed;
    }
    private void Start()
    {
        money = PlayerPrefs.GetInt(Config.PREFS_MONEY, 0);
        lc = LevelCreator.instance;
       playerCard =lc.playerCharacter;
    }
    private void OnGameFailed()
    {
        TouchManager.Instance.isActive = false;
    }
    private void OnTouchBegan(TouchInput touch)
    {
        if (playerState == PlayerState.Play)
        {
            RaycastHit2D hit = Physics2D.Raycast(touch.FirstWorldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.transform.TryGetComponent<Card>(out Card card))
            {
                if (lc.CardIsSighted(card,1))
                {
                    Debug.Log(card.name + " " + card.x + " " + card.y);
                    playerState = PlayerState.Idle;
                    StartCoroutine(card.CardClicked(playerCard));
                }
               
            }
        }
    }

    private void OnDisable()
    {
        TouchManager.Instance.onTouchBegan -= OnTouchBegan;
        onGameFailed -= OnGameFailed;
    }
   

}
public enum PlayerState
{
    Play,
    Idle,
}
