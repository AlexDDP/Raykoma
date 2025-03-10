using UnityEngine;
using TMPro;
using System;

public class crocEater : MonoBehaviour
{
    private Rigidbody2D rb;
    public int peopleEaten = 0;
    public TMP_Text eatenText;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            peopleEaten++;
            eatenText.text = "People Eaten: " + peopleEaten;

            Destroy(collision.gameObject);
        }
    }
}   


