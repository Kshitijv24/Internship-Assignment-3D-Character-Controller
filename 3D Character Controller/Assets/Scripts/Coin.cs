using UnityEngine;

public class Coin : MonoBehaviour
{
    public void CollectCoin()
    {
        CoinCollectionManager.Instance.IncrementCollectedCoin();
        Destroy(gameObject);
    }
}
