using HelloScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{

    public List<Card> prefabList;
    public List<CardData> cardsData;
    public List<CardData> allCardsData;

    private void Awake()
    {
        //foreach (Card card in prefabList)
        //{
        //    ObjectPooler.instance.PoolObject(card.gameObject, 50);
        //}


    }
    public Card NewCardCreateWithCardID(int cardIndex, int x, int y)
    {
        CardData cardData = allCardsData[cardIndex];
        // Card currentCard =  ObjectPooler.instance.GetPooledObject(cardData.card.gameObject).GetComponent<Card>();
        Card currentCard = Instantiate(cardData.card.gameObject).GetComponent<Card>();
        currentCard.gameObject.SetActive(false);
        currentCard.SetCard(cardData, x, y);
        currentCard.PlaceCard(new Vector2(LevelCreator.cardWidth * x, LevelCreator.cardHeight * y));
        return currentCard;
    }
    public Card NewCardCreateWithIndex(int cardIndex, int x, int y)
    {
        CardData cardData = cardsData[cardIndex];
        // Card currentCard =  ObjectPooler.instance.GetPooledObject(cardData.card.gameObject).GetComponent<Card>();
        Card currentCard = Instantiate(cardData.card.gameObject).GetComponent<Card>();
        currentCard.gameObject.SetActive(false);
        currentCard.SetCard(cardData, x, y);
        currentCard.PlaceCard(new Vector2(LevelCreator.cardWidth * x, LevelCreator.cardHeight * y));
        return currentCard;
    }
    public Card NewCardCreateWithIndex(int x, int y)
    {
        CardData cardData = cardsData[Random.Range(0, cardsData.Count)];
        // Card currentCard =  ObjectPooler.instance.GetPooledObject(cardData.card.gameObject).GetComponent<Card>();
        Card currentCard = Instantiate(cardData.card.gameObject).GetComponent<Card>();
        currentCard.gameObject.SetActive(false);
        currentCard.SetCard(cardData, x, y);
        currentCard.PlaceCard(new Vector2(LevelCreator.cardWidth * x, LevelCreator.cardHeight * y));
        return currentCard;
    }
    public Card NewCardCreateWithID(int cardID, int x, int y)
    {
        CardData cardData = GetCardDataWithID(cardID);
        // Card currentCard =  ObjectPooler.instance.GetPooledObject(cardData.card.gameObject).GetComponent<Card>();
        Card currentCard = Instantiate(cardData.card.gameObject).GetComponent<Card>();
        currentCard.gameObject.SetActive(false);
        currentCard.SetCard(cardData, x, y);
        currentCard.PlaceCard(new Vector2(LevelCreator.cardWidth * x, LevelCreator.cardHeight * y));
        return currentCard;
    }
    public Card NewCardCreateWithPrefab(Card prefab, CardData data, int x, int y)
    {
        Card currentCard = Instantiate(prefab).GetComponent<Card>();
        currentCard.gameObject.SetActive(true);
        currentCard.SetCard(data, x, y);
        currentCard.PlaceCard(new Vector2(LevelCreator.cardWidth * x, LevelCreator.cardHeight * y));
        return currentCard;
    }
    public CardData GetCardDataWithID(int cardID)
    {
        foreach (CardData data in cardsData)
        {
            if (data.ID == cardID)
                return data;
        }
        return null;
    }
}

