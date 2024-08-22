using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Slider healthSlider;

    private void Start() => healthSlider.value = HealthLogic.Instance.GetCurrentHealth();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            HealthLogic.Instance.DamagePlayer(50f);
            healthSlider.value = HealthLogic.Instance.GetCurrentHealth() / HealthLogic.Instance.GetMaxHealth();
        }
    }
}
