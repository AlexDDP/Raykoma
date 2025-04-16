using TMPro;
using UnityEngine;

public class TextColorChanger : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Assign in inspector or via code
    public Color targetColor = Color.red; // Default color to change to
    public float colorChangeSpeed = 1.0f; // Speed of transition (for optional smooth fade)
    public bool cycleColors = true; // Enable to auto cycle colors

    private Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow, Color.cyan };
    private int currentColorIndex = 0;
    private float timer = 0f;

    void Start()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponent<TextMeshProUGUI>();

        if (textMeshPro != null)
            textMeshPro.color = targetColor;
    }

    void Update()
    {
        if (cycleColors)
        {
            timer += Time.deltaTime * colorChangeSpeed;
            if (timer >= 1f)
            {
                timer = 0f;
                currentColorIndex = (currentColorIndex + 1) % colors.Length;
                textMeshPro.color = colors[currentColorIndex];
            }
        }
    }

    // Call this from other scripts to change color
    public void SetTextColor(Color newColor)
    {
        if (textMeshPro != null)
        {
            targetColor = newColor;
            textMeshPro.color = targetColor;
        }
    }
}
