using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelloScripts;
[CreateAssetMenu(fileName ="Level",menuName ="Data/LevelData",order =2)]
public class LevelData : ScriptableObject
{
    public int levelId;
    public Vector2Int playerPosition;
    public Vector2Int exitPosition;
    //public Card[] levelCards;
    //public int[] cardProbability;
    public Array2DInt levelCardIDs;
}
