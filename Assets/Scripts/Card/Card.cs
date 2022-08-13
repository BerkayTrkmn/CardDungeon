using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Card : MonoBehaviour
{
    public int cardId;
    private string cardName;
    private GameObject characterGO;
    public int x;
    public int y;
    public TextMeshPro attackText;
    public TextMeshPro healthText;
    [SerializeField] private Transform characterPoint;
    [SerializeField] private Collider2D col;
    public void SetCard(CardData cardData ,int _x, int _y)
    {
        x = _x;
        y = _y;
        cardId = cardData.ID;
        cardName = cardData.cardName;
        characterGO = cardData.characterGO;
        SetCharacter(cardData.characterData);
    }

    public void SetCharacter(CharacterData characterData)
    {
        GameObject tempCharacterGO = Instantiate(characterGO);
        tempCharacterGO.transform.parent = characterPoint;
        tempCharacterGO.transform.localPosition = Vector3.zero;

        Character tempCharacter=  tempCharacterGO.GetComponent<Character>();
        tempCharacter.SetCharacter(characterData.health,characterData.attack);
        tempCharacter.SetCharacterText(attackText, healthText);
        tempCharacter.card = this;
    
    }

    public virtual void PlaceCard(Vector3 position)
    {
        transform.position = position;
    }

}
