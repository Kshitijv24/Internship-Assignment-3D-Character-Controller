using UnityEngine;
using TMPro;

/// <summary>
/// Manages the coin display in the UI using TextMeshProUGUI.
/// </summary>
public class CoinUI : MonoBehaviour
{
    /// <summary>
    /// Reference to the TextMeshProUGUI component that displays the coin value.
    /// This should be assigned in the Unity Editor.
    /// </summary>
    [SerializeField] private TextMeshProUGUI coinValue;

    /// <summary>
    /// Updates the coin UI every frame.
    /// </summary>
    private void Update() => UpdateCoinsUI();

    /// <summary>
    /// Updates the coin value text in the UI to reflect the current
    /// collected coins and the total coins available in the game.
    /// </summary>
    private void UpdateCoinsUI() =>
        coinValue.text =
        CoinCollectionManager.Instance.GetCollectedCoin().ToString()
        + "/"
        + CoinCollectionManager.Instance.GetTotalCoins();
}
