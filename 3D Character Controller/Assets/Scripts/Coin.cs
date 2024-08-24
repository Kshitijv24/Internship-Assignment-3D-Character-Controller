using UnityEngine;

/// <summary>
/// The Coin class represents a coin object in the game that can be collected by the player.
/// </summary>
public class Coin : MonoBehaviour
{
    /// <summary>
    /// This method is called when the coin is collected by the player.
    /// It increments the count of collected coins and then destroys the coin object.
    /// </summary>
    public void CollectCoin()
    {
        // Increment the collected coin count in the CoinCollectionManager singleton instance
        CoinCollectionManager.Instance.IncrementCollectedCoin();

        // Destroy the coin game object to remove it from the scene
        Destroy(gameObject);
    }
}
