using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Character", menuName = "Data/Character", order = 1)]

public class CharacterData : ScriptableObject
{
    public int health;
    public int attack;
}
