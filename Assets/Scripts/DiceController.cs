using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using TMPro;

public class DiceController : MonoBehaviour
{
    private Rigidbody rb;
    public TextMeshProUGUI diceCount;
    // private bool isRolling = false;
    public int result;
    public UnityEvent<int> diceTriggerEvent;
    public GameObject gmo;

    GameManager gm;

    private void Start()
    {
        gm = gmo.GetComponent<GameManager>();
        // rb = GetComponent<Rigidbody>();
        diceTriggerEvent = new UnityEvent<int>();
        diceTriggerEvent.AddListener(calculateDiceValue);
    }
    public void calculateDiceValue(int dicevalue)
    {
        // if (isRolling == true)
        // {
        // isRolling = false;
        result = Random.Range(1, 7);
        // result = dicevalue;
        gm.diceRolled.Invoke(result);
        DisplayResult();
        // }
    }
    //private void OnMouseDown()
    // {

    //     if (!isRolling)
    //     {
    //         RollDice();
    //     }
    // }

    private void RollDice()
    {
        // isRolling = true;
        // rb.AddForce(0, 350, 0);
        // rb.AddTorque(55, 50, 15, ForceMode.Impulse);
        //Invoke("DisplayResult", 2.0f);
    }

    private void DisplayResult()
    {
        diceCount.text = "Dice:" + result;
        Debug.Log("Dice rolled: " + result);
    }



}
