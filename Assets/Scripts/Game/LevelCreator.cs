using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelloScripts;
public class LevelCreator : MonoBehaviour
{
    public static LevelCreator instance;
    [SerializeField] private float cardHeight = 1.5f;
    [SerializeField] private float cardwidth = 1.5f;
    [SerializeField] private int levelHeight = 5;
    [SerializeField] private int levelWidth = 5;
    private CardFactory cardFactory;
    public static Card[,] levelCards;
    public List<Character> playerCharacters;
    public List<CardData> playerCharacterDatas;
    public ExitDoor exitDoor;
    public DungeonObjectData exitDoorData;
    public Character playerCharacter;
    public Vector2Int playerCharacterStartPoint = new Vector2Int(0, 0);
    public Camera mainCamera;
    private void Awake()
    {
        instance = this;
        mainCamera = Camera.main;
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
            for (int x = 0; x < levelWidth; x++)
            {
                Card tempCard = cardFactory.NewCardCreate(0, x, y);
                tempCard.PlaceCard(new Vector2(cardwidth * x, cardHeight * y));
                tempCard.gameObject.SetActive(true);
                levelCards[x, y] = tempCard;
            }
        }
    }
    public void CreateRandomLevel()
    {
        playerCharacter = (Character)cardFactory.NewCardCreate(playerCharacters[0], playerCharacterDatas[0], playerCharacterStartPoint.x, playerCharacterStartPoint.y);
        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                Card tempCard;
                if (x == playerCharacterStartPoint.x && y == playerCharacterStartPoint.y)
                {
                    tempCard = playerCharacter;
                    mainCamera.transform.parent = playerCharacter.transform;
                }
                else if (x == levelWidth - 1 && y == levelHeight - 1)
                {
                    tempCard = cardFactory.NewCardCreate(exitDoor, exitDoorData, x, y);
                    tempCard.gameObject.SetActive(false);
                }
                else
                    tempCard = cardFactory.NewCardCreate(Random.Range(0, cardFactory.cardsData.Count), x, y);

                tempCard.PlaceCard(new Vector2(cardwidth * x, cardHeight * y));
                if (IsSighted(tempCard))
                    tempCard.gameObject.SetActive(true);
            }
        }
    }
    public bool IsSighted(Card levelCard)
    {
        int distanceFromPlayer = Mathf.Abs(playerCharacter.x - levelCard.x) + Mathf.Abs(playerCharacter.y - levelCard.y);
        //int playerPosition = playerCharacter.x + playerCharacter.y;
        int sight = playerCharacter.sight;
        if (sight >= distanceFromPlayer)
            return true;

        return false;
    }

}
