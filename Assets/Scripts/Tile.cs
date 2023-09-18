using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] bool isPlaceable;
    [SerializeField] Tower towerPB;
    //Property to return the boolean
    public bool IsPlaceable{get{return isPlaceable;}}

    GridManager gridManager;
    Vector2Int coordinates= new Vector2Int();
    Pathfinder pathfinder;

    void Awake() 
    {
        gridManager=FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void Start() 
    {
        if(gridManager!=null){
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable){
                gridManager.BlockNode(coordinates);
            }
        }
    }
    private void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isSuccessful = towerPB.CreateTower(towerPB, transform.position);
            if(isSuccessful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }
            
        }
    }
}
