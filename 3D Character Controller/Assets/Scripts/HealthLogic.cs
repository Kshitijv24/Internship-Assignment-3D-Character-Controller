using UnityEngine;

public class HealthLogic : MonoBehaviour
{
    public static HealthLogic Instance { get; private set; }

    [SerializeField] float maxHealth = 100f;
    [SerializeField] float currentHealth;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start() => currentHealth = maxHealth;

    public float GetCurrentHealth() => currentHealth;

    public float GetMaxHealth() => maxHealth;

    public void DamagePlayer(float damageAmount)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damageAmount;
    }
}
