using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Photon.Pun;

public class Countdown : MonoBehaviour
{

    [SerializeField]
    private Text timerText;
    [SerializeField]
    private bool startOnLoad = false;
    [SerializeField]
    private bool hideCountdownUntil = false;
    [SerializeField]
    private float timeLeftToShowCountdown = 10.0f;
    [SerializeField]
    private int secunds;
    [SerializeField]
    private UnityEvent OnCountownFinished;

    private bool startCountdown = false;

    private float time;

    private void Awake()
    {
        startCountdown = startOnLoad;
    }

    private void Start()
    {
        time = secunds;
        timerText.text = time.ToString();
        if (hideCountdownUntil)
        {
            timerText.enabled = false;
        }

    }

    void Update()
    {
        if (!startCountdown)
            return;
        time -= Time.deltaTime;
        updateTimer(time);

        if (hideCountdownUntil && !GameManager.instance.isManager && time <= timeLeftToShowCountdown)
        {
            timerText.enabled = true;
        }

        if (time <= 0 && !GameManager.instance.isManager)
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
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        if (OnCountownFinished != null)
            OnCountownFinished.Invoke();
    }

    public void StartCountdown()
    {
        startCountdown = true;
    }

}
