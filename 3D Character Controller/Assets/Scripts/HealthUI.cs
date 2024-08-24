using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class handles the UI representation of the player's health in the game.
/// It updates a health slider based on the player's current health and allows
/// for testing health reduction via a key press.
/// </summary>
public class HealthUI : MonoBehaviour
{
    /// <summary>
    /// Reference to the player's health logic, used to get current and max health values.
    /// </summary>
    [SerializeField] private Health healthLogic;

    /// <summary>
    /// UI slider that visually represents the player's health.
    /// </summary>
    private Slider healthSlider;

    /// <summary>
    /// Initializes the health slider by finding it within the child components.
    /// </summary>
    private void Awake() => healthSlider = GetComponentInChildren<Slider>();

    /// <summary>
    /// Sets the initial value of the health slider based on the player's current health.
    /// </summary>
    private void Start() => healthSlider.value = healthLogic.GetCurrentHealth();

    /// <summary>
    /// Continuously updates the health UI and allows for testing health reduction when the "H" key is pressed.
    /// </summary>
    private void Update()
    {
        UpdateHealthUI();

        // For testing purposes: reduces player's health by 50 when the "H" key is pressed.
        if (Input.GetKeyDown(KeyCode.H))
            healthLogic.DamagePlayer(50f);
    }

    /// <summary>
    /// Updates the value of the health slider to reflect the player's current health as a percentage.
    /// </summary>
    private void UpdateHealthUI() => healthSlider.value = healthLogic.GetCurrentHealth() / healthLogic.GetMaxHealth();
}
