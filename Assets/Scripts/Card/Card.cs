using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//TODO: inheriteance or data implenement?
public class Card : MonoBehaviour
{
    private int cardId;
    private string cardName;
    private GameObject characterGO;
    [SerializeField] private TextMeshPro attackText;
    [SerializeField] private TextMeshPro HealthText;
    [SerializeField] private Transform characterPoint;
    public void SetCard(int _cardID,string _cardName,GameObject _characterGO)
    {
        cardId = _cardID;
        cardName = _cardName;
        characterGO = _characterGO;
        SetCharacter();
    }

    public void SetCharacter()
    {
        GameObject character = Instantiate(characterGO);
        character.transform.parent = characterPoint;
        character.transform.localPosition = Vector3.zero;
    }

    public virtual void PlaceCard(Vector3 position)
    {
        transform.position = position;
    }

}
