using UnityEngine;

public class CoinCollectionManager : MonoBehaviour
{
    public static CoinCollectionManager Instance { get; private set; }

    [SerializeField] int totalCoins = 5;
    [SerializeField] GameObject coinCollectionCompletePopUp;

    int collectedCoin;
    bool isClosed;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start() => coinCollectionCompletePopUp.SetActive(false);

    private void Update() => CoinCollectionCompleted();

    public int GetCollectedCoin() => collectedCoin;

    public int GetTotalCoins() => totalCoins;

    public void IncrementCollectedCoin() => collectedCoin++;

    public void CoinCollectionCompleted()
    {
        if (collectedCoin >= totalCoins && !isClosed)
            coinCollectionCompletePopUp.SetActive(true);
    }

    public void CloseCoinCollectionCompletePopUp()
    {
        isClosed = true;
        coinCollectionCompletePopUp.SetActive(false);
    }
}
