using UnityEngine;

public class GridPlacementSystem : MonoBehaviour
{
    private GridXZ<GridObject> grid;

    private void Awake()
    {
        int gridWidth = 10;
        int gridHeight = 10;
        float cellSize = 10f;
        grid = new GridXZ<GridObject>(gridWidth, gridHeight, cellSize, Vector3.zero, (GridXZ<GridObject> g, int x, int y) => new GridObject(g, x, y));
    }



//THE OBJECT TO SPAWN
    public class GridObject
    {
        private int x;
        private int z;
        private GridXZ<GridObject> grid;

        public GridObject(GridXZ<GridObject> grid, int x, int z)
        {
            this.grid = grid;
            this.x = x;
            this.z = z;

        }

        public override string ToString()
        {
            return x + ", " + z;
        }


    }
}
