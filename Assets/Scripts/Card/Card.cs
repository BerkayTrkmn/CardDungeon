using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public abstract class Card : MonoBehaviour
{
    public int cardId;
    protected string cardName;
    protected GameObject characterGO;
    public int x;
    public int y;
    public TextMeshPro attackText;
    public TextMeshPro healthText;
    [SerializeField] protected Transform characterPoint;
    [SerializeField] protected Collider2D col;
    public virtual void SetCard(CardData cardData ,int _x, int _y)
    {
        x = _x;
        y = _y;
        cardId = cardData.ID;
        cardName = cardData.cardName;
        characterGO = cardData.characterGO;
       
    }
    public virtual void PlaceCard(Vector3 position)
    {
        transform.position = position;
    }

}
