using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public enum CardType
    {
        BACKWARDS, IMPRISON
    }
    public int totalTiles = 0;


    public bool isPlayerTurn = true;

    public UnityEvent<int> diceRolled = new UnityEvent<int>();
    public UnityEvent<int> playerturn = new UnityEvent<int>();
    public UnityEvent<int> enemyturn = new UnityEvent<int>();
    public UnityEvent<CardType> applyCard = new UnityEvent<CardType>();
    void Start()
    {
        totalTiles = GameObject.FindGameObjectsWithTag("Tile").Length;
        diceRolled.AddListener(diceRolledHandler);
    }
    public void toggleTurn()
    {
        isPlayerTurn = !isPlayerTurn;
    }
    public void diceRolledHandler(int b)
    {
        if (isPlayerTurn == true)
        {
            playerturn.Invoke(b);
        }
        else
        {
            enemyturn.Invoke(b);
        }
        toggleTurn();
    }
    public void applyBackwardsCard()
    {
        Debug.Log("GoBack");
        applyCard.Invoke(CardType.BACKWARDS);

    }
    public void applyImprisonCard()
    {
        applyCard.Invoke(CardType.IMPRISON);

    }



}
