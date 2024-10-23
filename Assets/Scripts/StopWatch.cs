using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    public Text display;
    private bool isRunning = false;
    private float elapsedTime = 0.0f;

    private void StartTimer()
    {
        if (isRunning)
            return;
        Restart();
        print("Started");
    }

    private void Restart()
    {
        isRunning = true;
        elapsedTime = 0.0f;
    }

    private void StopTimer()
    {
        isRunning = false;
        print("Stopped");
    }

    void Update()
    {
        if (isRunning)
            elapsedTime += Time.deltaTime;

        if (display == null)
            return;

        TimeSpan span = TimeSpan.FromSeconds(elapsedTime);
        display.text = $"{span.Hours:d2}:{span.Minutes:d2}:{span.Seconds:d2}";
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Collision");
        if (other.CompareTag("Start"))
            StartTimer();
        else if (other.CompareTag("Finish"))
            StopTimer();
    }
}
