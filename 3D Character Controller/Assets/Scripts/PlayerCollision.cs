using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Health healthLogic;

    private void Awake() => healthLogic = GetComponent<Health>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
            healthLogic.DamagePlayer(50f);

        Coin coin = other.GetComponent<Coin>();

        if (coin)
            coin.CollectCoin();
    }
}
