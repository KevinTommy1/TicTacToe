using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    GameObject gameBoard;
    public Sprite[] images;
    private bool unplayed = true;
    private bool playerTurn = true;

    private void Start()
    {
        spriteRenderer.sprite = null;
    }

    private void OnMouseDown()
    {
        if (gameBoard.GetComponent<GameScript>().PlayerTurn() == 0) // Assuming 0 is the player's turn
        {
            spriteRenderer.sprite = images[gameBoard.GetComponent<GameScript>().PlayerTurn()];
            gameBoard.GetComponent<GameScript>().PlayerTurn(); // Advance to the AI's turn
            AiTurn();
        }
    }

    void AiTurn()
    {
        if (gameBoard.GetComponent<GameScript>().PlayerTurn() == 1) // Assuming 1 is the AI's turn
        {
            // Select a random token on the gameboard
            GameObject token = SelectToken();
            if (token != null && unplayed)
            {
                // Update the sprite for the selected token
                token.GetComponent<SpriteRenderer>().sprite = images[Random.Range(0, images.Length)];
                gameBoard.GetComponent<GameScript>().PlayerTurn(); // Advance to the player's turn
            }
        }
    }

    GameObject SelectToken()
    {
        // This method should return a random token on the gameboard
        // You can implement this method based on your game's logic
        // For example, you could use a list of all tokens on the gameboard and select one at random
        // For now, let's just return a random child of the gameboard
        Transform[] tokens = gameBoard.GetComponentsInChildren<Transform>();
        return tokens[Random.Range(0, tokens.Length)].gameObject;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameBoard = GameObject.Find("game_board");
    }
}
