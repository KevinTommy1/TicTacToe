using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    GameObject gameBoard;
    public Sprite[] images;
    private bool unplayed = true;

    static List<GameObject> unplayedTokens = new List<GameObject>();

    void Start()
    {
        //Initialize the list of unplayed tokens
        Transform[] tokens = gameBoard.GetComponentsInChildren<Transform>();
        foreach (Transform token in tokens)
        {
            if (token.gameObject != gameObject && token.gameObject != gameBoard)
            {
                unplayedTokens.Add(token.gameObject);
            }
        }

        spriteRenderer.sprite = null;
    }

    private void OnMouseDown()
    {
        if (gameBoard.GetComponent<GameScript>().PlayerTurn() != 0) return; // Assuming 0 is the player's turn
        spriteRenderer.sprite = images[gameBoard.GetComponent<GameScript>().PlayerTurn()];
        gameBoard.GetComponent<GameScript>().PlayerTurn(); // Advance to the AI's turn
        AiTurn();
        if (unplayedTokens.Contains(gameObject))
        {
            unplayedTokens.Remove(gameObject);
        }
    }

    void AiTurn()
    {
        if (gameBoard.GetComponent<GameScript>().PlayerTurn() != 1) return;
        GameObject token = SelectToken();
        if (token == null) return;
        token.GetComponent<SpriteRenderer>().sprite = images[gameBoard.GetComponent<GameScript>().PlayerTurn()];
        gameBoard.GetComponent<GameScript>().PlayerTurn();
        if (unplayedTokens.Contains(token))
        {
            unplayedTokens.Remove(token);
        }
    }

    GameObject SelectToken()
    {
        // Select a random token from the list of unplayed tokens
        if (unplayedTokens.Count > 0)
        {
            GameObject token = unplayedTokens[Random.Range(0, unplayedTokens.Count)];
            if (unplayedTokens.Contains(token))
            {
                unplayedTokens.Remove(token);
            }
            return token;
        }
        else
        {
            return null;
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameBoard = GameObject.Find("game_board");
    }
}