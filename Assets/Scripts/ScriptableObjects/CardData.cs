using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Card",menuName ="Data/Card",order = 0)]
public class CardData : ScriptableObject
{
    public int ID;
    public string cardName;
    public GameObject characterGO;
    public int health;
    public int attack;
}
