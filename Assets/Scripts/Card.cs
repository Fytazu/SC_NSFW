using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Card : ScriptableObject
{
    //Basic card values
    public int cardID;
    public string cardName;
    public CardSprite sprite;
    public string dialogue;
    public string leftQuote;
    public string rightQuote;
    //Impact values
    //Left
    public int kSafetyLeft;
    public int kFaithLeft;
    public int kTreasureLeft;
    public int kPeopleLeft;
    public int kArmyLeft;
    //Right
    public int kSafetyRight;
    public int kFaithRight;
    public int kTreasureRight;
    public int kPeopleRight;
    public int kArmyRight;

    public void Left()
    {
        Debug.Log(cardName + " swiped left");
        //Appending the values
        GameManager.kingdomArmy += kArmyLeft;
        GameManager.kingdomFaith += kFaithLeft;
        GameManager.kingdomPeople += kPeopleLeft;
        GameManager.kingdomSafety += kSafetyLeft;
        GameManager.kingdomTreasure += kTreasureLeft;
    }
    public void Right()
    {
        Debug.Log(cardName + " swiped right");
        //Appending the values
        GameManager.kingdomArmy += kArmyRight;
        GameManager.kingdomFaith += kFaithRight;
        GameManager.kingdomPeople += kPeopleRight;
        GameManager.kingdomSafety += kSafetyRight;
        GameManager.kingdomTreasure += kTreasureRight;
    }

    
}
