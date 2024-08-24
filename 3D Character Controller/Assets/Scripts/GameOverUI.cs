using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    // Reference to the player's health component
    [SerializeField] Health health;

    // Reference to the Game Over popup UI element
    [SerializeField] GameObject gameOverPopUp;

    // Time delay before showing the Game Over popup after the player dies
    [SerializeField] float showGameOverPopUpAfterThisTime = 3f;

    // Flag to determine if the Game Over popup has been closed
    bool isClosed;

    // Called when the script instance is being loaded
    // Initially hides the Game Over popup
    private void Start() => gameOverPopUp.SetActive(false);

    // Called once per frame
    private void Update()
    {
        // If the player is dead, invoke the ShowGameOverPopUp method after the specified time delay
        if (health.IsPlayerDead())
            Invoke(nameof(ShowGameOverPopUp), showGameOverPopUpAfterThisTime);
    }

    // Shows the Game Over popup if it hasn't been closed yet
    private void ShowGameOverPopUp()
    {
        if (!isClosed)
            gameOverPopUp.SetActive(true);
    }

    // Closes the Game Over popup and sets the isClosed flag to true
    public void CloseGameOverPopUp()
    {
        isClosed = true;
        gameOverPopUp.SetActive(false);
    }
}
