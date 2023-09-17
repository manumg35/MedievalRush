using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = {Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
    GridManager gridManager;
    Dictionary<Vector2Int,Node> grid;
    private void Awake() {
        gridManager=FindObjectOfType<GridManager>();
        if(gridManager!=null){
            grid = gridManager.Grid;
        }
    }
    void Start()
    {
        ExploreNeightbors();
    }
    void ExploreNeightbors(){

        List<Node> neightbors = new List<Node>();
        
        foreach(Vector2Int direction in directions){
            Vector2Int neightborCoords = currentSearchNode.coordinates+direction;
            if(grid.ContainsKey(neightborCoords)){
                neightbors.Add(grid[neightborCoords]);
                //TODO: remove after testing
                grid[neightborCoords].isExplored=true;
                grid[currentSearchNode.coordinates].isPath=true;
            }
        }
        
        
    }

}
