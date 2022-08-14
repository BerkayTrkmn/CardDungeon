using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Card", menuName = "Data/CharacterCard", order = 0)]
public class CharacterCardData : CardData
{
    public int health;
    public int attack;
    public int sight = 1;
}
