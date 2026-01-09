using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static float CoinsCollected;
    public TextMeshProUGUI coinText;
    

    void Update()
    {
        coinText.text = "Coins: " + CoinsCollected;
    }
}
