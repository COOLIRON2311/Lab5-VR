using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

enum FlickState
{
    Inactive,
    Started,
    Completed
}

public class StopWatch : MonoBehaviour
{
    public Text display;
    public GameObject canvas;
    private bool isRunning = false;
    private float elapsedTime = 0.0f;
    public InputActionReference inputReference;
    #region Flick
    private InputAction inputAction;
    private bool visible = true;
    private FlickState wristFlick = FlickState.Inactive;
    private float flickStartedTime;
    private float flickEndedTime;
    #endregion

    private void StartTimer()
    {
        if (isRunning)
            return;
        Restart();
        // print("Started");
    }

    private void Restart()
    {
        isRunning = true;
        elapsedTime = 0.0f;
    }

    private void StopTimer()
    {
        isRunning = false;
        // print("Stopped");
    }

    private void Awake()
    {
        inputAction = inputReference.action;
    }

    static float WrapAngle(float angle)
    {
        angle %= 360;
        angle = angle > 180 ? angle - 360 : angle;
        return angle;
    }

    void Update()
    {
        Quaternion rotation = inputAction.ReadValue<Quaternion>();
        float angle = WrapAngle(rotation.eulerAngles.z);

        if (angle > 90.0 || angle < -90.0)
            return;

        if (wristFlick == FlickState.Inactive && angle > 45.0f)
        {
            wristFlick = FlickState.Started;
            flickStartedTime = Time.time;
            // print("flick started");
        }

        if (wristFlick == FlickState.Started && angle < 0.0f)
        {
            wristFlick = FlickState.Completed;
            flickEndedTime = Time.time;
            // print("flick ended");
        }

        if (wristFlick == FlickState.Completed)
        {
            if (flickEndedTime - flickStartedTime < 1.0f)
            {
                visible = !visible;
                canvas.SetActive(visible);
                wristFlick = FlickState.Inactive;
            }
            // print($"visible: {visible}");
            // print(flickEndedTime - flickStartedTime);
        }

        // print(angle);

        if (isRunning)
            elapsedTime += Time.deltaTime;

        if (display == null)
            return;

        TimeSpan span = TimeSpan.FromSeconds(elapsedTime);
        display.text = $"{span.Hours:d2}:{span.Minutes:d2}:{span.Seconds:d2}";
    }

    private void OnTriggerEnter(Collider other)
    {
        // print("Collision");
        if (other.CompareTag("Start"))
            StartTimer();
        else if (other.CompareTag("Finish"))
            StopTimer();
    }
}
