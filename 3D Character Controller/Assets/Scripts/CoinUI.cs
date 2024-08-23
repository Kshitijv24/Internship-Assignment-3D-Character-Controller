using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinValue;

    private void Update() => UpdateCoinsUI();

    private void UpdateCoinsUI() => 
        coinValue.text = 
        CoinCollectionManager.Instance.GetCollectedCoin().ToString() 
        + "/" 
        + CoinCollectionManager.Instance.GetTotalCoins();
}
