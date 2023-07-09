using TMPro;
using UnityEngine;

[ExecuteAlways]
public class GetCoords : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;

    [SerializeField] Transform cube;
    TextMeshPro textMP;
    private Vector2 coords;
    Waypoint waypoint;


    private void Awake()
    {
        textMP = GetComponent<TextMeshPro>();
        textMP.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
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
        ColorCoordinates();
            
    }

    private void ColorCoordinates()
    {
        if (!waypoint.IsPlaceable)
        {
            textMP.color = blockedColor;
        }
        else
        {
            textMP.color = defaultColor;
        }
    }
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
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
