using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.coinCount++;
            Debug.Log("เหรียญที่เก็บได้: " + CoinManager.coinCount);
            Destroy(gameObject); // ลบเหรียญเมื่อชน Player
        }
    }
}
