using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    HealthLogic healthLogic;

    private void Awake() => healthLogic = GetComponent<HealthLogic>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
            healthLogic.DamagePlayer(50f);

        if (other.CompareTag("Coin"))
        {

        }
    }
}
