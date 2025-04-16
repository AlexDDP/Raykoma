using TMPro;
using UnityEngine;

public class RainbowTextColor : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float speed = 1f;

    private float hue = 0f;

    void Start()
    {
        if (text == null)
            text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        hue += Time.deltaTime * speed;
        if (hue > 1f) hue -= 1f;

        Color rainbowColor = Color.HSVToRGB(hue, 1f, 1f);
        text.color = rainbowColor;
    }
}
