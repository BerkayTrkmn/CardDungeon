using HelloScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private TouchManager touchManager;

    private void OnEnable()
    {
       TouchManager.Instance.onTouchBegan += OnTouchBegan;
    }

    private void OnTouchBegan(TouchInput touch)
    {
        RaycastHit2D hit = Physics2D.Raycast(touch.FirstWorldPosition, Vector2.zero);
        Card card;
        if (hit.collider != null && hit.collider.transform.TryGetComponent<Card>(out card))
        {
                Debug.Log(card.name + " " + card.x +" " + card.y);
            
        }
        
    
    }

    private void OnDisable()
    {
        TouchManager.Instance.onTouchBegan -= OnTouchBegan;
    }

}
