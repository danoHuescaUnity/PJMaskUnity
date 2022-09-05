using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{

    [SerializeField]
    private Text timerText;
    [SerializeField]
    private int secunds;
    [SerializeField]
    private UnityEvent OnCountownFinished;

    private bool startCountdown = false;

    private float time;

    private void Start()
    {
        time = secunds;
        timerText.text = time.ToString();
    }

    void Update()
    {
        if (!startCountdown)
            return;
        time -= Time.deltaTime;
        updateTimer(time);

        if (time <= 0)
        {
            startCountdown = false;
            OnCountDownFinished();
        }
    }

    private void updateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = seconds.ToString();
    }

    void OnCountDownFinished()
    {
        if (OnCountownFinished != null)
            OnCountownFinished.Invoke();
    }

    public void StartCountdown()
    {
        startCountdown = true;
    }

}
