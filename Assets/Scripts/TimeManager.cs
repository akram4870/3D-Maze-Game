// TimerManager.cs
// Manages a timer displayed in a TextMeshProUGUI component.
// Starts and stops the timer based on external triggers.
// Updates the timer display to show elapsed time in minutes and seconds.


using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component to display the timer
    private float startTime; // The time when the timer starts
    private bool timerRunning = false; // Flag indicating whether the timer is running or not

    private void Start()
    {
        // Initialize the timer text to display initial time
        timerText.text = "Time: 00.00.00";
    }

    private void Update()
    {
        // Update the timer text if the timer is running
        if (timerRunning)
        {
            float t = Time.time - startTime; // Calculate the elapsed time
            string minutes = ((int)t / 60).ToString("00"); 
            string seconds = (t % 60).ToString("00.00"); 
            timerText.text = "Time: " + minutes + ":" + seconds; // Update the timer text
        }
    }

    // Method to start the timer
    public void StartTimer()
    {
        startTime = Time.time; // Set the start time to the current time
        timerRunning = true; // Set the timer running flag to true
    }

    // Method to stop the timer
    public void StopTimer()
    {
        timerRunning = false; // Set the timer running flag to false
    }
}
