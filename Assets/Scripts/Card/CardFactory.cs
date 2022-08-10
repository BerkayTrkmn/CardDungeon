using HelloScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour 
{

    [SerializeField]private Card prefab;
    [SerializeField] private List<CardData> cardsData;

    public Card NewCardCreate(int cardId)
    {
        CardData cardData = cardsData[cardId];
         Card currentCard =  ObjectPooler.instance.GetPooledObject(prefab.gameObject).GetComponent<Card>();
        currentCard.SetCard(cardData.ID,cardData.cardName,cardData.characterGO);
        return currentCard;
    }
}

