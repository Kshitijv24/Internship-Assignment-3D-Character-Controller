using UnityEngine;

/// <summary>
/// Handles player collisions with different game objects, such as hazards and coins.
/// </summary>
public class PlayerCollision : MonoBehaviour
{
    /// <summary>
    /// Reference to the Health component that manages the player's health.
    /// </summary>
    private Health healthLogic;

    /// <summary>
    /// Called when the script instance is being loaded. Initializes the reference to the Health component.
    /// </summary>
    private void Awake() => healthLogic = GetComponent<Health>();

    /// <summary>
    /// Called when the player enters a trigger collider. Detects collisions with hazards and coins.
    /// </summary>
    /// <param name="other">The Collider that the player collided with.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is tagged as a "Hazard"
        if (other.CompareTag("Hazard"))
        {
            // Inflict damage to the player if they collide with a hazard
            healthLogic.DamagePlayer(50f);
        }

        // Check if the collided object has a Coin component
        Coin coin = other.GetComponent<Coin>();

        // If the object is a coin, collect it
        if (coin != null)
            coin.CollectCoin();
    }
}
