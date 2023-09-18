using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoords;
    public Vector2Int StartCoords{get{return startCoords;}}
    [SerializeField] Vector2Int destinationCoords;
    public Vector2Int DestinationCoords{get {return destinationCoords;}}

    Node startNode;
    Node destinationNode;
    Node currentSearchNode;

    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();
    Vector2Int[] directions = {Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left};
    GridManager gridManager;
    Dictionary<Vector2Int,Node> grid = new Dictionary<Vector2Int, Node>();
    private void Awake() {
        gridManager=FindObjectOfType<GridManager>();
        if(gridManager!=null){
            grid = gridManager.Grid;
            startNode= grid[startCoords];
            destinationNode= grid[destinationCoords];
            
        }
        
        
    }
    void Start()
    {
        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        return GetNewPath(startCoords);
    }
    public List<Node> GetNewPath(Vector2Int coordinates)
    {
        gridManager.ResetNodes();
        BreadthFrirstSearch(coordinates);
        return BuildPath();
    }
    void ExploreNeightbors(){

        List<Node> neightbors = new List<Node>();
        
        foreach(Vector2Int direction in directions){
            Vector2Int neightborCoords = currentSearchNode.coordinates+direction;
            if(grid.ContainsKey(neightborCoords)){
                neightbors.Add(grid[neightborCoords]);
                
            }
        }
        foreach(Node neightbor in neightbors){
            if(!reached.ContainsKey(neightbor.coordinates )&& neightbor.isWalkable){
                neightbor.conectedTo = currentSearchNode;
                reached.Add(neightbor.coordinates, neightbor);
                frontier.Enqueue(neightbor);
            }
        }
        
    }

    void BreadthFrirstSearch(Vector2Int coordinates){
        startNode.isWalkable=true;
        destinationNode.isWalkable=true;

        frontier.Clear();
        reached.Clear();

        bool isRunning=true;

        frontier.Enqueue(grid[coordinates]);
        reached.Add(coordinates, grid[coordinates]);

        while(frontier.Count>0 && isRunning){

            currentSearchNode=frontier.Dequeue();
            currentSearchNode.isExplored=true;
            ExploreNeightbors();

            if(currentSearchNode.coordinates==destinationCoords){
                isRunning=false;
            }

        }
        
    }

    List<Node> BuildPath(){

        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;
        path.Add(currentNode);
        currentNode.isPath=true;

        while(currentNode.conectedTo!=null){
            currentNode=currentNode.conectedTo;
            path.Add(currentNode);
            currentNode.isPath=true;
        }

        path.Reverse();

        return path;
    }

    public bool WillBlockPath(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            bool previusState = grid[coordinates].isWalkable;

            grid[coordinates].isWalkable=false;
            List<Node> newPath = GetNewPath();
            grid[coordinates].isWalkable=previusState;

            if(newPath.Count<=1)
            {
                GetNewPath();
                return true;
            }
            
        }

        return false;
    }

    public void NotifyReceivers(){
        BroadcastMessage("RecalculatePath", false, SendMessageOptions.DontRequireReceiver);
    }

}
