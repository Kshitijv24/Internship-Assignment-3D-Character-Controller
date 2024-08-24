using UnityEngine;

/// <summary>
/// Manages the collection of coins in the game and controls the UI pop-up when all coins are collected.
/// </summary>
public class CoinCollectionManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of the CoinCollectionManager.
    /// </summary>
    public static CoinCollectionManager Instance { get; private set; }

    /// <summary>
    /// Total number of coins required to complete the collection.
    /// </summary>
    [SerializeField] int totalCoins = 5;

    /// <summary>
    /// The UI pop-up that appears when all coins have been collected.
    /// </summary>
    [SerializeField] GameObject coinCollectionCompletePopUp;

    /// <summary>
    /// The number of coins currently collected by the player.
    /// </summary>
    int collectedCoin;

    /// <summary>
    /// Indicates whether the coin collection completion pop-up has been closed.
    /// </summary>
    bool isClosed;

    /// <summary>
    /// Initializes the singleton instance. Ensures only one instance of this class exists.
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// Disables the coin collection completion pop-up at the start of the game.
    /// </summary>
    private void Start() => coinCollectionCompletePopUp.SetActive(false);

    /// <summary>
    /// Checks if the coin collection is complete in each frame update.
    /// </summary>
    private void Update() => CoinCollectionCompleted();

    /// <summary>
    /// Gets the current number of collected coins.
    /// </summary>
    /// <returns>The number of collected coins.</returns>
    public int GetCollectedCoin() => collectedCoin;

    /// <summary>
    /// Gets the total number of coins required to complete the collection.
    /// </summary>
    /// <returns>The total number of coins.</returns>
    public int GetTotalCoins() => totalCoins;

    /// <summary>
    /// Increments the count of collected coins by one.
    /// </summary>
    public void IncrementCollectedCoin() => collectedCoin++;

    /// <summary>
    /// Checks if all coins have been collected and displays the completion pop-up if true.
    /// </summary>
    public void CoinCollectionCompleted()
    {
        if (collectedCoin >= totalCoins && !isClosed)
            coinCollectionCompletePopUp.SetActive(true);
    }

    /// <summary>
    /// Closes the coin collection completion pop-up.
    /// </summary>
    public void CloseCoinCollectionCompletePopUp()
    {
        isClosed = true;
        coinCollectionCompletePopUp.SetActive(false);
    }
}
