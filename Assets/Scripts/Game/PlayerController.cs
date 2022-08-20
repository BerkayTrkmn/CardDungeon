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
    private void OnEnable()
    {
        TouchManager.Instance.onTouchBegan += OnTouchBegan;
    }
    private void Start()
    {
        playerCard = LevelCreator.instance.playerCharacter;
    }
    private void OnTouchBegan(TouchInput touch)
    {
        if (playerState == PlayerState.Play)
        {
            RaycastHit2D hit = Physics2D.Raycast(touch.FirstWorldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.transform.TryGetComponent<Card>(out Card card))
            {
                Debug.Log(card.name + " " + card.x + " " + card.y);
                playerState = PlayerState.Idle;
                StartCoroutine(card.CardClicked(playerCard));
            }
        }
    }

    private void OnDisable()
    {
        TouchManager.Instance.onTouchBegan -= OnTouchBegan;
    }

}
public enum PlayerState
{
    Play,
    Idle,
}
