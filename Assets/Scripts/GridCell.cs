using UnityEngine;

public class GridCell : MonoBehaviour
{
    public enum CellState
    {
        Empty,
        X,
        O
    }

    public CellState state = CellState.Empty;
}