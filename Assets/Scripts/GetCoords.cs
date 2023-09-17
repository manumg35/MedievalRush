using TMPro;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class GetCoords : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor= new Color(1f,0.5f,0f);

    [SerializeField] Transform cube;
    TextMeshPro textMP;
    private Vector2Int coords = new Vector2Int();
    GridManager gridManager;


    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        textMP = GetComponent<TextMeshPro>();
        textMP.enabled = true;
        
        
        DisplayCoordinates();
    }


    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        ToggleLabels();
        SetLabelColor();
            
    }

    private void SetLabelColor()
    {
        if(gridManager==null){return;}

        Node node = gridManager.GetNode(coords);

        if(node==null){return;}

        if (!node.isWalkable)
        {
            textMP.color = blockedColor;
        }
        else if(node.isPath)
        {
            textMP.color = pathColor;
            
        }
        else if(node.isExplored){
            textMP.color = exploredColor;
        }
        else{
            textMP.color = defaultColor;
        }
    }
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("TOGGLE LABLE");
            textMP.enabled = !textMP.IsActive() ;
            
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
        string newName = coords.x.ToString() + "," + coords.y.ToString();
        transform.parent.name = newName;
    }
}
