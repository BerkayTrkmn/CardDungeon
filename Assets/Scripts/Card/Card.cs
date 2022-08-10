using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Card : MonoBehaviour
{
    private int cardId;
    private string cardName;
    private GameObject characterGO;
    [SerializeField] private TextMeshPro attackText;
    [SerializeField] private TextMeshPro healthText;
    [SerializeField] private Transform characterPoint;
    [SerializeField] private Collider2D col;
    public void SetCard(CardData cardData)
    {
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
    
    }

    public virtual void PlaceCard(Vector3 position)
    {
        transform.position = position;
    }

}
