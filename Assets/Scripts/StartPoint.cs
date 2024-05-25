using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Find the TimerManager instance in the scene
            TimerManager timerManager = FindObjectOfType<TimerManager>();

            // Start the timer in the TimerManager
            timerManager.StartTimer();
        }
    }
}
