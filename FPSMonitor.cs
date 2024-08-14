using UnityEngine;
using UnityEngine.UI;

public class FPSMonitor : MonoBehaviour
{
    public Text fpsText;
    public float updateInterval = 1.0f; // Update interval in seconds

    private float timer;
    private int frameCount;

    void Start()
    {
        if (fpsText == null)
        {
            Debug.LogError("FPS Text not assigned. Please assign a Text component to the script.");
            enabled = false;
            return;
        }

        UpdateFPSDisplay();
    }

    void Update()
    {
        timer += Time.deltaTime;
        frameCount++;

        if (timer >= updateInterval)
        {
            UpdateFPSDisplay();
            timer = 0f;
            frameCount = 0;
        }
    }

    void UpdateFPSDisplay()
    {
        // Calculate frames per second
        float fps = frameCount / updateInterval;

        // Display FPS on the UI text
        fpsText.text = "FPS: " + Mathf.RoundToInt(fps);
    }
}
