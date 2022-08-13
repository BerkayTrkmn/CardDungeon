using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelloScripts;
public class LevelCreator : MonoBehaviour
{
    [SerializeField]private Card card;
    [SerializeField] private float cardHeight = 1.5f;
    [SerializeField] private float cardwidth = 1.5f;
    [SerializeField] private int levelHeight = 5;
    [SerializeField] private int levelWidth = 5;
    private CardFactory cardFactory;
    public static Card[,] levelCards;
    public CharacterCard[] playerCharacters;
    public ExitDoor exitDoor;
    private void Awake()
    {
        levelCards = new Card[levelWidth, levelHeight];
        cardFactory = GetComponent<CardFactory>();
    }
    private void Start()
    {
        CreateRandomLevel();
    }
    public void CreateLevel()
    {
        //TODO : With level scriptable object
        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x< levelWidth; x++)
            {
                Card tempCard = cardFactory.NewCardCreate(0,x,y);
                tempCard.PlaceCard(new Vector2(cardwidth * x, cardHeight * y));
                tempCard.gameObject.SetActive(true);
                levelCards[x, y] = tempCard;
            }
        }
    }
    public void CreateRandomLevel()
    {
        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                Card tempCard;
                if (x == 0 && y == 0)
                {
                    tempCard = cardFactory.NewCardCreate(playerCharacters[0].cardId, x, y);
                }
                else if (x == levelWidth && y == levelHeight)
                {
                   // tempCard = cardFactory.NewCardCreate(exitDoor.cardId, x, y);
                }
                 tempCard = cardFactory.NewCardCreate(Random.Range(0,cardFactory.cardsData.Count),x,y);
                tempCard.PlaceCard(new Vector2(cardwidth * x, cardHeight * y));
                tempCard.gameObject.SetActive(true);
            }
        }
    }


}
