using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;

    [SerializeField] int unityGridSize =10;
    public int UnityGridSize{get {return unityGridSize;}}
    
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid{get{return grid;}}
    private void Awake()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinates){
        if(grid.ContainsKey(coordinates)){
            return grid[coordinates];
        }
        return null;
    }

    public void BlockNode(Vector2Int coordinates){
        if(grid.ContainsKey(coordinates)){
            grid[coordinates].isWalkable=false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position){
        Vector2Int coords = new Vector2Int();
        coords.x =Mathf.RoundToInt(position.x / unityGridSize);
        coords.y = Mathf.RoundToInt(position.z / unityGridSize);

        return coords;
    }
    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates){
        Vector3 position = new Vector3();
        position.x=coordinates.x*unityGridSize;
        position.z=coordinates.y*unityGridSize;
        
        return position;
    }

    void CreateGrid()
    {
        for(int x=0;x<gridSize.x;x++)
        {
            for(int y=0; y<gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
                
            }
        }
    }
}
