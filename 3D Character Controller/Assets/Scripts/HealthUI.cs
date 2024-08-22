using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    HealthLogic healthLogic;

    private void Awake() => healthLogic = GetComponent<HealthLogic>();

    private void Start() => healthSlider.value = healthLogic.GetCurrentHealth();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            healthLogic.DamagePlayer(50f);
            healthSlider.value = healthLogic.GetCurrentHealth() / healthLogic.GetMaxHealth();
        }
    }
}
