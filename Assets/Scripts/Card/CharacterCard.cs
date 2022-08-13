using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCard : Card
{
    
    public override void SetCard(CardData cardData, int _x, int _y)
    {
        base.SetCard(cardData, _x, _y);
        
        SetCharacter(((CharacterCardData)cardData).characterData);
    }

    public void SetCharacter(CharacterData characterData)
    {
        GameObject tempCharacterGO = Instantiate(characterGO);
        tempCharacterGO.transform.parent = characterPoint;
        tempCharacterGO.transform.localPosition = Vector3.zero;

        Character tempCharacter = tempCharacterGO.GetComponent<Character>();
        tempCharacter.SetCharacter(characterData.health, characterData.attack);
        tempCharacter.SetCharacterText(attackText, healthText);
        tempCharacter.card = this;

    }

}
