using UnityEngine;
using UnityEngine.UI;

public class GridCellUI : MonoBehaviour
{
    public Button button;
    public GridCell gridCell;

    void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        // Handle player input
        gridCell.state = GridCell.CellState.X;
    }
}