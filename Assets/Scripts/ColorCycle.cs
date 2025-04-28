using UnityEngine;

public class ColorCycle : MonoBehaviour
{
    public Color firstColor = Color.red; // First color (default red)
    public Color secondColor = Color.green; // Second color (default green)
    public float timeBetweenSwitches = 2f; // Time in seconds to wait before switching

    private SpriteRenderer sr;
    private float timer;
    private bool isFirstColor = true;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = firstColor; // Start with the first color
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenSwitches)
        {
            timer = 0f;
            SwitchColor();
        }
    }

    void SwitchColor()
    {
        if (isFirstColor)
        {
            sr.color = secondColor;
        }
        else
        {
            sr.color = firstColor;
        }

        isFirstColor = !isFirstColor;
    }
}
