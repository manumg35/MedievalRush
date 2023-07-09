using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject towerPB;
    //Property to return the boolean
    public bool IsPlaceable{get{return isPlaceable;}}


    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(towerPB, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
