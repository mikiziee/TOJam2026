using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UIElements;

public class TestGrid : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private LayerMask layerMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = new Grid(20, 20, 10f, Vector3.zero );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition3D(layerMask);
            int value = grid.GetValue(position);
            grid.AddValue(position, 20, 1, 10);
        }
    }
}
