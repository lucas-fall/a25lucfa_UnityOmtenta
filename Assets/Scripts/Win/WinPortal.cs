using UnityEngine;
using UnityEngine.UI; // Required for the Win Text

public class WinPortal : MonoBehaviour
{
    public float coinsNeeded = 100f;
    public Sprite openPortalSprite;
    public GameObject winText;
    
    // Reference to your existing Coin script (Change "CoinManager" to your actual script name)
    public CoinManager coinScript; 

    private SpriteRenderer spriteRenderer;
    private bool isPortalOpen = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        winText.SetActive(false); // Hide win text at start
    }

    void Update()
    {
        // Check if we have enough coins to "open" the portal
        if (CoinManager.CoinsCollected >= coinsNeeded && !isPortalOpen)
        {
            OpenPortal();
        }
    }

    void OpenPortal()
    {
        isPortalOpen = true;
        spriteRenderer.sprite = openPortalSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the portal is open AND the object entering is the Player
        if (isPortalOpen && other.CompareTag("Player"))
        {
            winText.SetActive(true);
            
            // Disable the player's movement/object
            other.gameObject.SetActive(false); 
            
            Debug.Log("You Win!");
        }
    }
}