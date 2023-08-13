using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diceside : MonoBehaviour
{
    DiceController dice;
    public int value;
    void Start()
    {

        dice = gameObject.GetComponentInParent<DiceController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        dice.diceTriggerEvent.Invoke(value);
    }
}
