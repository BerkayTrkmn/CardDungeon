using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Character : Entity
{

    public int health;
    public int attack;

    public void SetCharacter(int _health, int _attack)
    {
        health = _health;
        attack = _attack;
    }
    public void SetCharacterText(TextMeshPro attackText, TextMeshPro healthText)
    {
        SetAttackText(attackText);
        SetHealthText(healthText);
    }
    public void SetAttackText(TextMeshPro attackText)
    {
        attackText.text = attack.ToString();
    }
    public void SetHealthText(TextMeshPro healthText)
    {
        healthText.text = health.ToString();
    }
}
