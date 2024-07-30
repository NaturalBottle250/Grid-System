using UnityEngine;

public class CustomGrid : MonoBehaviour
{
    
    [SerializeField] private int width, height;
    [SerializeField] private Vector3 cellDimensions;
    
    //Enum declared below
    [SerializeField] private CellType type;

    private GridCell[,] cells;

    [SerializeField] private GameObject defaultCell;









    public GridCell Get(int x, int z)
    {
        return cells[z,x];
    }

    public void GenerateGrid()
    {
        Debug.Log($"Generating with {height} height and {width} width!");
        
        
        foreach(Transform child in transform)
            Destroy(child.gameObject);

        cells = new GridCell[height, width];
        for (int zIndex = 0; zIndex < height; zIndex++)
        {
            for (int xIndex = 0; xIndex < width; xIndex++)
            {
                GameObject o =Instantiate(defaultCell, new Vector3(cellDimensions.x*xIndex, 0, cellDimensions.z*zIndex), Quaternion.identity);
                o.transform.localScale = cellDimensions;
                GridCell gridCell = o.AddComponent<GridCell>();
                gridCell.Coordinates = new Vector3(xIndex, 0, zIndex);
                ScaleToSize(o);
                o.transform.parent = transform;

            }
            
        }
    }



    private void ScaleToSize(GameObject cell)
    {
        Renderer renderer = cell.GetComponent<Renderer>();

        if (!renderer)
        {
            Debug.LogWarning("No renderer found on wanted block, please add a renderer to your tile");
            return;
        }

        Vector3 bounds = renderer.bounds.size;
        Debug.Log($"Bounds: {bounds}");
        float xFactor = cellDimensions.x / bounds.x, zFactor = cellDimensions.z / bounds.z;
        
        Debug.Log($"Scale: {xFactor}, {zFactor}");

        cell.transform.localScale = new Vector3(cellDimensions.x*xFactor, 1, cellDimensions.z*zFactor);
    }
    public enum CellType
    {
        Square, Hex
    }

    public int Width
    {
        get => width;
        set => width = value;
    }

    public int Height
    {
        get => height;
        set => height = value;
    }

    public CellType Type
    {
        get => type;
        set => type = value;
    }

    public GridCell[,] Cells
    {
        get => cells;
        set => cells = value;
    }

    public Vector3 CellDimensions
    {
        get => cellDimensions;
        set => cellDimensions = value;
    }

    public GameObject DefaultCell
    {
        get => defaultCell;
        set => defaultCell = value;
    }
}
