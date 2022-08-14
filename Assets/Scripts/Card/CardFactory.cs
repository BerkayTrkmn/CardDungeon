using HelloScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour 
{

    [SerializeField]private List<Card> prefabList;
    public List<CardData> cardsData;

    private void Awake()
    {
        foreach (Card card in prefabList)
        {
            ObjectPooler.instance.PoolObject(card.gameObject, 50);
        }
      

    }
    public Card NewCardCreate(int cardId, int x,int y)
    {
        CardData cardData = cardsData[cardId];
         Card currentCard =  ObjectPooler.instance.GetPooledObject(cardData.card.gameObject).GetComponent<Card>();
        currentCard.SetCard(cardData,x, y);
        return currentCard;
    }
}

