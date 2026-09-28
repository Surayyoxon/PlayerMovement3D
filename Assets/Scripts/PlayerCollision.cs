using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private int coinCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Coin")) return;

        coinCount++;
        Debug.Log("Yig‘ilgan tangalar: " + coinCount);

        Destroy(other.gameObject);
    }
}
