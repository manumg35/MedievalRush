using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node 
{
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node conectedTo;

    public Node(Vector2Int coords, bool isWalkable, bool isExplored, bool isPath, Node conectedTo)
    {
        this.coordinates = coords;
        this.isWalkable = isWalkable;
        this.isExplored = isExplored;
        this.isPath = isPath;
        this.conectedTo = conectedTo;
    }

}
