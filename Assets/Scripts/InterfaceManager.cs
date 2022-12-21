using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    //Card
    public GameManager gameManager;
    public GameObject card;
    //UI icons
    public Image kingdomSafety;
    public Image kingdomFaith;
    public Image kingdomTreasure;
    public Image kingdomPeople;
    public Image kingdomArmy;
    //UI impact icons
    public Image kingdomSafetyImpact;
    public Image kingdomFaithImpact;
    public Image kingdomTreasureImpact;
    public Image kingdomPeopleImpact;
    public Image kingdomArmyImpact;
    void Update()
    {
        //UI icons 
        kingdomSafety.fillAmount = (float) GameManager.kingdomSafety / GameManager.maxValue;
        kingdomFaith.fillAmount = (float) GameManager.kingdomFaith / GameManager.maxValue;
        kingdomTreasure.fillAmount = (float) GameManager.kingdomTreasure / GameManager.maxValue;
        kingdomPeople.fillAmount = (float) GameManager.kingdomPeople / GameManager.maxValue;
        kingdomArmy.fillAmount = (float) GameManager.kingdomArmy / GameManager.maxValue;

        //UI impact icon
        //Right
        if(gameManager.direction == "right")
        {
            if (gameManager.currentCard.kSafetyRight != 0)
                kingdomSafetyImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kFaithRight != 0)
                kingdomFaithImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kTreasureRight != 0)
                kingdomTreasureImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kPeopleRight != 0)
                kingdomPeopleImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kArmyRight != 0)
                kingdomArmyImpact.transform.localScale = new Vector3(1, 1, 0);
            Debug.Log("1");
        }
        //Left
        else if(gameManager.direction == "left")
        {
            if (gameManager.currentCard.kSafetyLeft != 0)
                kingdomSafetyImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kFaithLeft != 0)
                kingdomFaithImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kTreasureLeft != 0)
                kingdomTreasureImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kPeopleLeft != 0)
                kingdomPeopleImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kArmyLeft != 0)
                kingdomArmyImpact.transform.localScale = new Vector3(1, 1, 0);
            Debug.Log("2");
        }
        else
        {
            kingdomSafetyImpact.transform.localScale = new Vector3(0, 0, 0);
            kingdomFaithImpact.transform.localScale = new Vector3(0, 0, 0);
            kingdomTreasureImpact.transform.localScale = new Vector3(0, 0, 0);
            kingdomPeopleImpact.transform.localScale = new Vector3(0, 0, 0);
            kingdomArmyImpact.transform.localScale = new Vector3(0, 0, 0);
            Debug.Log("3");
        }
    }
}
