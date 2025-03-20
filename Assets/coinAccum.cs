using UnityEngine;
using TMPro;
using System;

public class coinAccum : MonoBehaviour
{
    public int coins = 0;
    public TMP_Text coinsText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            coins++;
            coinsText.text = "Coins: " + coins;

            Destroy(other.gameObject);
        }
    }
}


