using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerColor : MonoBehaviour
{
    private PlayerInput playerInput;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChoseColor();
    }

    private void ChoseColor()
    {
        int playerID = playerInput.playerIndex;

        switch (playerID)
        {
            case 0:
                spriteRenderer.color = Color.red;
                break;
            case 1:
                spriteRenderer.color = Color.blue;
                break;
            case 2:
                spriteRenderer.color = Color.green;
                break;
            case 3:
                spriteRenderer.color = Color.yellow;
                break;
            default:
                Debug.LogError("Invalid player ID!");
                break;
        }
    }
}
