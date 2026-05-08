using UnityEngine;
using CodeMonkey.Utils;

public class TestGrid : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private LayerMask layerMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = new Grid(4,2, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition3D(layerMask), 56);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition3D(layerMask)));
        }
    }
}
