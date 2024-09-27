using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public int gridSize = 9;
    private GridCell[,] gridCells;

    void Start()
    {
        gridCells = new GridCell[gridSize, gridSize];
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                gridCells[i, j] = gameObject.AddComponent<GridCell>();
            }
        }
    }
}
