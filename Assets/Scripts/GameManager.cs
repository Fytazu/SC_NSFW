using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //KINGDOM
    public static int kingdomSafety = 20;
    public static int kingdomFaith = 20;
    public static int kingdomTreasure = 20;
    public static int kingdomPeople = 20;
    public static int kingdomArmy = 20;
    public static int maxValue = 100;
    public int minValue = 0;

    //Gameobjects
    public GameObject cardGameObject;
    public GameObject pendingCardGameObject;
    public CardController mainCardController;
    public SpriteRenderer cardSpriteRenderer;
    public ResourceManager resourceManager;
    public Vector2 defaultPositionCard;
    //Tweawking variables
    public float fMovingSpeed;
    public float fRotationSpeed;
    public float fSideMargin;
    public float fSideTrigger;
    public float divideValue;
    public float backgroundDivideValue;
    float alphaText;
    public Color textColor;
    public Color actionBackgroundColor;
    public float fTransparency = 0.7f;
    public float fRotationCoefficient;
    Vector3 pos;
    //UI
    public TMP_Text display;
    public TMP_Text characterDialogue;
    public TMP_Text actionQuote;
    public SpriteRenderer actionBackground;
    //Card variables
    public string direction;
    private string leftQuote;
    private string rightQuote;
    public Card currentCard;
    public Card testCard;
    //Substituting the card
    public bool isSubstituting = false;
    public Vector3 cardRotation; //default one
    public Vector3 currentRotation; // the current rotation of the card
    public Vector3 initRotation; // initial rotation of the card
    void Start()
    {
        LoadCard(testCard);
    }

    void UpdateDialogue()
    {
        actionQuote.color = textColor;
        actionBackground.color = actionBackgroundColor;
        if (cardGameObject.transform.position.x < 0)
        {
            actionQuote.text = leftQuote;
        }
        else
        {
            actionQuote.text = rightQuote;
        }
    }

    void Update()
    {
        //KINGDOM VALUES LOGIC
        //Debug.Log(kingdomSafety);


        //Dialogue text handing
        textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / divideValue, 1);
        actionBackgroundColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / backgroundDivideValue, fTransparency);
        if (cardGameObject.transform.position.x > fSideTrigger)
        {
            direction = "right";
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Right();
                NewCard();
                
            }
        }
        else if(cardGameObject.transform.position.x > fSideMargin)
        {
            direction = "right";
        }
        else if (cardGameObject.transform.position.x > -fSideMargin)
        {
            direction = "none";
            textColor.a = 0;
            
        }
        else if (cardGameObject.transform.position.x > -fSideTrigger)
        {
            direction = "left";
        }
        else
        {
            direction = "left";
            UpdateDialogue();
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Left();
                NewCard();
            }
        }
        UpdateDialogue();
        //Movement
        if (Input.GetMouseButton(0) && mainCardController.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardGameObject.transform.position = pos;
            cardGameObject.transform.eulerAngles = new Vector3(0, 0, cardGameObject.transform.position.x * fRotationCoefficient);
        }
        else if (!isSubstituting)
        {
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, defaultPositionCard, fMovingSpeed);
            cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (isSubstituting)
        {
            cardGameObject.transform.eulerAngles = Vector3.MoveTowards(cardGameObject.transform.eulerAngles, cardRotation, fRotationSpeed);
        }

        //UI
        display.text = "" + textColor.a;

        characterDialogue.text = currentCard.dialogue;

        //Rotating the card
        if (cardGameObject.transform.eulerAngles == cardRotation)
        {
            isSubstituting = false;
        }

    }
    

    public void LoadCard(Card card)
    {
        cardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        leftQuote = card.leftQuote;
        rightQuote = card.rightQuote;
        currentCard = card;
        characterDialogue.text = card.dialogue;
        //Reseting the position of the card
        cardGameObject.transform.position = defaultPositionCard;
        cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        //Initialise od the substitution
        isSubstituting = true;
        cardGameObject.transform.eulerAngles = initRotation;
    }


    public void NewCard()
    {
        int rollDice = Random.Range(0, resourceManager.cards.Length);
        LoadCard(resourceManager.cards[rollDice]);
    }

}
