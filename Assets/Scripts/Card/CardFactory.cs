using HelloScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour 
{

    [SerializeField]private Card prefab;
    public List<CardData> cardsData;

    public Card NewCardCreate(int cardId, int x,int y)
    {
        CardData cardData = cardsData[cardId];
         Card currentCard =  ObjectPooler.instance.GetPooledObject(prefab.gameObject).GetComponent<Card>();
        currentCard.SetCard(cardData,x, y);
        return currentCard;
    }
}

