using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] GameObject gameOverPopUp;
    [SerializeField] float showGameOverPopUpAfterThisTime = 3f;

    bool isClosed;

    private void Start() => gameOverPopUp.SetActive(false);

    private void Update()
    {
        if (health.IsPlayerDead())
            Invoke(nameof(ShowGameOverPopUp), showGameOverPopUpAfterThisTime);
    }

    private void ShowGameOverPopUp()
    {
        if (!isClosed)
            gameOverPopUp.SetActive(true);
    }

    public void CloseGameOverPopUp()
    {
        isClosed = true;
        gameOverPopUp.SetActive(false);
    }
}
