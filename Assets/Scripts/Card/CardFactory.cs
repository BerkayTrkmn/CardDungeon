using HelloScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour 
{

    public List<Card> prefabList;
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
        // Card currentCard =  ObjectPooler.instance.GetPooledObject(cardData.card.gameObject).GetComponent<Card>();
         Card currentCard = Instantiate(cardData.card.gameObject).GetComponent<Card>();
        currentCard.gameObject.SetActive(false);
        currentCard.SetCard(cardData,x, y);
        currentCard.PlaceCard(new Vector2(LevelCreator.cardWidth * x, LevelCreator.cardHeight * y));
        return currentCard;
    }
    public Card NewCardCreate(Card prefab,CardData data, int x, int y)
    {
        Card currentCard = Instantiate(prefab).GetComponent<Card>();
        currentCard.gameObject.SetActive(true);
        currentCard.SetCard(data, x, y);
        currentCard.PlaceCard(new Vector2(LevelCreator.cardWidth * x, LevelCreator.cardHeight * y));
        return currentCard;
    }
}

