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
    private void Awake()
    {
        cardFactory = GetComponent<CardFactory>();
        ObjectPooler.instance.PoolObject(card.gameObject,50);
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
                Card tempCard = cardFactory.NewCardCreate(0);
                tempCard.PlaceCard(new Vector2(cardwidth * x, cardHeight * y));
                tempCard.gameObject.SetActive(true);
            }
        }
    }
    public void CreateRandomLevel()
    {
        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                Card tempCard = cardFactory.NewCardCreate(Random.Range(0,cardFactory.cardsData.Count));
                tempCard.PlaceCard(new Vector2(cardwidth * x, cardHeight * y));
                tempCard.gameObject.SetActive(true);
            }
        }
    }


}
