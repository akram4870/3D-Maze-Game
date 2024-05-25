using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool timerRunning = false;

    private void Start()
    {
        timerText.text = "Time: 00.00.00";
    }

    private void Update()
    {
        if (timerRunning)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00.00");
            timerText.text = "Time: " + minutes + ":" + seconds;
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }
}
