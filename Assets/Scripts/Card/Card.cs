using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public abstract class Card : MonoBehaviour
{
    public int cardId;
    protected string cardName;
    protected GameObject characterGO;
    [HideInInspector]public int x;
    [HideInInspector]public int y;
    protected Transform characterStatsParent;
    protected Transform nameShowerParent;
    protected Transform characterPoint;
    protected Collider2D col;
    protected virtual void OnEnable()
    {
        characterStatsParent = transform.GetChild(1);
        nameShowerParent = transform.GetChild(2);
        characterPoint = transform.GetChild(3);
        col = GetComponent<Collider2D>();
    }
    public virtual void SetCard(CardData cardData ,int _x, int _y)
    {
        x = _x;
        y = _y;
        cardId = cardData.ID;
        cardName = cardData.cardName;
       
    }
    public virtual void PlaceCard(Vector3 position)
    {
        transform.position = position;
    }

}
