using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static int coinCount = 0;
    public TextMeshProUGUI coinText;

    void Update()
    {
        if (coinText != null)
        {
            coinText.text = "X " + coinCount;
        }
    }
}
