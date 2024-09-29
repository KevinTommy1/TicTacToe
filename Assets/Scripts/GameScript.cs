using UnityEngine;

public class GameScript : MonoBehaviour
{ 
    int spriteIndex = -1;

    public int PlayerTurn()
    {
        spriteIndex++;
        return spriteIndex % 2;
    }
}
