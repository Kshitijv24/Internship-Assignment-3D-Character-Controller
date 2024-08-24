using UnityEngine;

/// <summary>
/// The Health class handles the health system for a player or any game object.
/// It manages the current health, max health, and provides methods to deal damage and check if the object is dead.
/// </summary>
public class Health : MonoBehaviour
{
    /// <summary>
    /// The maximum health value the object can have.
    /// This value is serialized so it can be set in the Unity Editor.
    /// </summary>
    [SerializeField] private float maxHealth = 100f;

    /// <summary>
    /// The current health of the object.
    /// This value is initialized to the maxHealth value in the Awake method.
    /// </summary>
    [SerializeField] private float currentHealth;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// Here, we initialize currentHealth to be equal to maxHealth.
    /// </summary>
    private void Awake() => currentHealth = maxHealth;

    /// <summary>
    /// Returns the current health of the object.
    /// </summary>
    /// <returns>The current health value.</returns>
    public float GetCurrentHealth() => currentHealth;

    /// <summary>
    /// Returns the maximum health of the object.
    /// </summary>
    /// <returns>The maximum health value.</returns>
    public float GetMaxHealth() => maxHealth;

    /// <summary>
    /// Reduces the current health by the specified damage amount.
    /// If the current health is already zero or less, no further damage is applied.
    /// </summary>
    /// <param name="damageAmount">The amount of damage to inflict.</param>
    public void DamagePlayer(float damageAmount)
    {
        if (currentHealth <= 0) return; // Prevent further damage if already dead

        currentHealth -= damageAmount; // Reduce current health by damageAmount
    }

    /// <summary>
    /// Checks if the object is dead, meaning its health is zero or less.
    /// </summary>
    /// <returns>True if the object is dead, false otherwise.</returns>
    public bool IsPlayerDead() => currentHealth <= 0;
}
