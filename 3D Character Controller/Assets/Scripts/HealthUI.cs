using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Health healthLogic;

    Slider healthSlider;

    private void Awake() => healthSlider = GetComponentInChildren<Slider>();

    private void Start() => healthSlider.value = healthLogic.GetCurrentHealth();

    private void Update()
    {
        UpdateHealthUI();

        if (Input.GetKeyDown(KeyCode.H))
            healthLogic.DamagePlayer(50f);
    }

    private void UpdateHealthUI() => healthSlider.value = healthLogic.GetCurrentHealth() / healthLogic.GetMaxHealth();
}
