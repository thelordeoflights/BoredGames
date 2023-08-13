using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCurrentCoordinates();

    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCurrentCoordinates();
            UpdateObjectName();
        }
    }
    void DisplayCurrentCoordinates()
    {
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 6);
        label.text = coordinates.y + "";
    }
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
