using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioClip pickupSound;

    [Header("Coin Value")]
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            CoinManager.CoinsCollected += coinValue;

            Destroy(gameObject);
        }
    }
}