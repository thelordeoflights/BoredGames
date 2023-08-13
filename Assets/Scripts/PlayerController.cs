using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool amIPlayer = true;
    // public ParticleSystem imprisonParticle;
    int dice;
    // public int currentTile;
    bool canMove = false;
    //bool inCastleP = true;
    bool hasBackwards = false;
    bool isreverse = false;
    public GameObject gmo;
    public int currentTile = 0;
    GameManager gm;
    int imprisoned = 0;


    void Start()
    {
        // MoveForward();
        gm = gmo.GetComponent<GameManager>();
        gm.diceRolled.AddListener(DiceRollHandler);
        if (amIPlayer == true)
        {
            gm.playerturn.AddListener(OnDiceRoll);
        }
        else
        {
            gm.applyCard.AddListener(cardhandler);
            gm.enemyturn.AddListener(OnDiceRoll);
        }
        // OnDiceRoll(11);
    }

    private void cardhandler(GameManager.CardType arg0)
    {
        if (arg0 == GameManager.CardType.BACKWARDS)
        {
            hasBackwards = true;
        }
        else if (arg0 == GameManager.CardType.IMPRISON)
        {
            imprisoned = 2;
            // imprisonParticle.Play();
        }
    }

    public void DiceRollHandler(int dicevalue)
    {
        if (hasBackwards == true && canMove)
        {
            enemyGoBack(dicevalue);
            hasBackwards = false;
        }

    }



    public int movementDirection = 1;
    void MovePlayer()
    {
        // transform.Translate(Vector3.forward * 2.0f);
        transform.position += new Vector3(0, 0, 6.0f * dice * movementDirection);
    }

    void OnDiceRoll(int a)
    {
        // Debug.Log(gm.isPlayerTurn);
        // Debug.Log(a);

        if (imprisoned > 0)
        {
            Debug.Log(imprisoned);
            imprisoned--;
            return;
        }

        dice = a;

        if (canMove == false && (dice == 1 || dice == 6))
        {
            canMove = true;
            dice = 1;

        }

        int targetTile = currentTile + dice * movementDirection;
        // Debug.Log(targetTile);
        if (targetTile >= gm.totalTiles || targetTile < 0)
        {
            return;
        }

        if (canMove == true)
        {
            currentTile = targetTile;
            MovePlayer();
        }
        if (targetTile == gm.totalTiles - 1)
        {
            movementDirection = -1;
        }
        if (targetTile == 0)
        {
            movementDirection = 1;
        }


    }
    public void enemyGoBack(int dicevalue)
    {
        movementDirection = movementDirection * -1;
        OnDiceRoll(dicevalue);
        movementDirection = movementDirection * -1;
    }


}
