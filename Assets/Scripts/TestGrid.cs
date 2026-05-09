using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class TestGrid : MonoBehaviour
{
    private Grid<HeatMapGridObject> grid;
    [SerializeField] private LayerMask layerMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = new Grid<HeatMapGridObject>(20, 20, 10f, Vector3.zero, (Grid<HeatMapGridObject> g, int x, int y)=> new HeatMapGridObject(g, x, y) );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition3D(layerMask);
            HeatMapGridObject heatMapGridObject = grid.GetGridObject(position);
            if(heatMapGridObject != null){
                heatMapGridObject.AddValue(45);
            }
        }
    }
}

public class HeatMapGridObject
{
    private const int  MIN = 0;
    private const int MAX = 100;
    private Grid <HeatMapGridObject> grid;
    private int x;
    private int y;
    public int value;

    public HeatMapGridObject(Grid<HeatMapGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void AddValue(int addValue)
    {
        value += addValue;
        value = Mathf.Clamp(value, MIN, MAX);
        grid.TriggerGridObjectChanged(x,y);
    }

    public float GetValueNormalized()
    {
        return (float)value/MAX;
    }
}