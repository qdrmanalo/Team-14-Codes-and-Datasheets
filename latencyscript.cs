using UnityEngine;
using UnityEngine.UI;

public class LatencyMonitor : MonoBehaviour
{
    public Text latencyText;
    public Text averageLatencyText;
    public int latencySampleCount = 300; // Number of samples for calculating average
    public float updateInterval = 0.2f; // Update interval in seconds

    
    private float timer;
    private int[] latencySamples;
    private int sampleIndex;

    void Start()
    {
        if (latencyText == null || averageLatencyText == null)
        {
            Debug.LogError("Latency Text or Average Latency Text not assigned. Please assign Text components to the script.");
            enabled = false;
            return;
        }

        latencySamples = new int[latencySampleCount];
        sampleIndex = 0;

        UpdateLatencyDisplay();
        UpdateAverageLatencyDisplay();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= updateInterval)
        {
            UpdateLatencyDisplay();
            if (sampleIndex < latencySampleCount) 
            {
                UpdateAverageLatencyDisplay();
            }
            timer = 0f;
        }
    }

    void UpdateLatencyDisplay()
    {
        // Simulate latency (replace this with your actual latency measurement logic)
        int latencyMilliseconds = SimulateLatency();

        // Display latency on the UI text
        latencyText.text = "Latency: " + latencyMilliseconds + " ms";

        if (sampleIndex < latencySampleCount) 
        {
            // Store latency in the samples array
            latencySamples[sampleIndex] = latencyMilliseconds;
            sampleIndex++;
        }
    }

    void UpdateAverageLatencyDisplay()
    {
        if (sampleIndex < latencySampleCount)
        {
            // Calculate the average of the stored latency samples
            float averageLatency = CalculateAverageLatency();

            // Display average latency on the UI text
            averageLatencyText.text = "Average Latency: " + Mathf.RoundToInt(averageLatency) + " ms";
        }
    }

    int SimulateLatency()
    {
        // Simulate latency by introducing a delay (replace this with your actual latency measurement logic)
        System.Threading.Thread.Sleep(50);

        // Return a simulated latency value (replace this with your actual latency measurement logic)
        return Random.Range(40, 80);
    }

    float CalculateAverageLatency()
    {
        // Calculate the average of the stored latency samples
        float sum = 0;
        for (int i = 0; i < sampleIndex; i++)
        {
            sum += latencySamples[i];
        }
        return sum / sampleIndex;
    }
}
