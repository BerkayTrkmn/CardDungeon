using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelloScripts;
public class LevelCreator : MonoBehaviour
{
    public static LevelCreator instance;
    public static float cardHeight = 2f;
    public static float cardWidth = 1.5f;
    public static int levelHeight = 5;
    public static int levelWidth = 5;
    public CardFactory cardFactory;
    public static Card[,] levelCards;
    public List<Character> playerCharacters;
    public List<CardData> playerCharacterDatas;
    public ExitDoor exitDoor;
    public DungeonObjectData exitDoorData;
    public Character playerCharacter;
    public Vector2Int playerCharacterStartPoint = new Vector2Int(0, 0);
    public Vector2Int exitDoorCreationPoint = new Vector2Int(levelWidth - 1, levelHeight - 1);
    public Camera mainCamera;
    public static int levelNumber = 1;
    public LevelData[] levels;
    Array2DInt levelData = null;
    private void Awake()
    {
        instance = this;
        mainCamera = Camera.main;
        levelCards = new Card[levelWidth, levelHeight];
        cardFactory = GetComponent<CardFactory>();
        levelNumber = PlayerPrefs.GetInt(Config.PREFS_LEVEL, 1);
        
    }
    private void Start()
    {
        LevelSelection();
        CreateLevel();
    }

  
    public void LevelSelection()
    {
        if(levelNumber-1 < levels.Length)
        {
            LevelData data = levels[levelNumber-1];
            playerCharacterStartPoint = data.playerPosition;
            exitDoorCreationPoint = data.exitPosition;
            levelData = data.levelCardIDs;
        }
      
    }

    public void CreateLevel()
    {
        
        playerCharacter = (Character)cardFactory.NewCardCreateWithPrefab(playerCharacters[0], playerCharacterDatas[0], playerCharacterStartPoint.x, playerCharacterStartPoint.y);
        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                Card tempCard;
                if (x == playerCharacterStartPoint.x && y == playerCharacterStartPoint.y)
                {
                    tempCard = playerCharacter;
                    mainCamera.transform.position = playerCharacter.transform.position + Vector3.back;
                    tempCard.GetComponent<Collider2D>().enabled = false;
                }
                else if (x == exitDoorCreationPoint.x && y == exitDoorCreationPoint.y)
                {
                    tempCard = cardFactory.NewCardCreateWithPrefab(exitDoor, exitDoorData, x, y);
                    tempCard.gameObject.SetActive(false);
                }
                else
                {
                    //If level no level data create random level
                    if(levelData != null)
                    tempCard = cardFactory.NewCardCreateWithIndex(levelData.GetCell(x, y), x, y);
                    else
                    tempCard = cardFactory.NewCardCreateWithIndex(Random.Range(0, cardFactory.cardsData.Count), x, y);
                }

                if (CardIsSighted(playerCharacter, tempCard))
                    tempCard.gameObject.SetActive(true);
                levelCards[x, y] = tempCard;
            }
        }
    }

    #region CardIsSighted Overloads
    public bool CardIsSighted(Character movingCard, Card levelCard)
    {
        if (levelCard is null) return false;
        int distanceFromPlayer = Mathf.Abs(movingCard.x - levelCard.x) + Mathf.Abs(movingCard.y - levelCard.y);
        int sight = movingCard.sight;
        if (sight >= distanceFromPlayer)
            return true;

        return false;
    }
    public bool CardIsSighted(Card levelCard)
    {
        if (levelCard is null) return false;
        int distanceFromPlayer = Mathf.Abs(playerCharacter.x - levelCard.x) + Mathf.Abs(playerCharacter.y - levelCard.y);
        int sight = playerCharacter.sight;
        if (sight >= distanceFromPlayer)
            return true;

        return false;
    }
    public bool CardIsSighted(Card levelCard, int sight)
    {
        if (levelCard is null) return false;
        int distanceFromPlayer = Mathf.Abs(playerCharacter.x - levelCard.x) + Mathf.Abs(playerCharacter.y - levelCard.y);
        if (sight >= distanceFromPlayer)
            return true;

        return false;
    }

    #endregion

    public void SetPlayerSightedCards(Character movingCharacter)
    {
        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                Card tempCard = levelCards[x, y];
                Debug.Log(x + "," + y + " " + CardIsSighted(movingCharacter, tempCard));
                if (CardIsSighted(movingCharacter, tempCard))
                    tempCard.gameObject.SetActive(true);
            }
        }
    }
    public void CloseAllLevelCards()
    {
        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                if (x == playerCharacter.x && y == playerCharacter.y) continue;
                levelCards[x, y].gameObject.SetActive(false);
            }
        }
    }
}

