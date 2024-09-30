using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    GameObject gameBoard;
    public Sprite[] images;
    private bool unplayed = true;

    private void Start()
    {
        spriteRenderer.sprite = null;
    }

    private void OnMouseDown()
    {
        if (!unplayed) return;
        spriteRenderer.sprite = images[gameBoard.GetComponent<GameScript>().PlayerTurn()];
        unplayed = false;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameBoard = GameObject.Find("game_board");
    }
}
