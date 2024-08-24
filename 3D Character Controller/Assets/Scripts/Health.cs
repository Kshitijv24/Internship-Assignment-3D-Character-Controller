using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float currentHealth;

    private void Awake() => currentHealth = maxHealth;

    public float GetCurrentHealth() => currentHealth;

    public float GetMaxHealth() => maxHealth;

    public void DamagePlayer(float damageAmount)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damageAmount;
    }

    public bool IsPlayerDead() => currentHealth <= 0;
}
