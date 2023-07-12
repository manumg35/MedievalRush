using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] bool isPlaceable;
    [SerializeField] Tower towerPB;
    //Property to return the boolean
    public bool IsPlaceable{get{return isPlaceable;}}


    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = towerPB.CreateTower(towerPB, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
