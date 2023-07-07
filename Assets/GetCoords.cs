using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class GetCoords : MonoBehaviour
{
    [SerializeField] Transform cube;
    TextMeshPro textMP;
    private Vector2 coords;

    private void Awake()
    {
        textMP = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }


    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    private void DisplayCoordinates()
    {
        coords.x =Mathf.RoundToInt(cube.position.x / 10);
        coords.y = Mathf.RoundToInt(cube.position.z / 10);


        textMP.text = coords.x.ToString() + "," + coords.y.ToString();
    }
    void UpdateObjectName()
    {
        transform.parent.name = coords.ToString();
    }
}
