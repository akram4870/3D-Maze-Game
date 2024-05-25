using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimerManager timerManager = FindObjectOfType<TimerManager>();
            timerManager.StartTimer();
        }
    }
}
