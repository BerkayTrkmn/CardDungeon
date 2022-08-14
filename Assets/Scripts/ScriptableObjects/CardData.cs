using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardData : ScriptableObject
{
    public int ID;
    public string cardName;
    public GameObject characterGO;
    public Card card;
}
