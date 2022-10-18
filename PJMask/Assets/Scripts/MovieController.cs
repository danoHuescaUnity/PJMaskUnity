using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class MovieController : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer m_videoPlayer = null;
    [SerializeField]
    private UnityEvent OnMovieFinishedPlaying;

    [SerializeField]
    private GameObject startButton = null;
    [SerializeField]
    private GameObject repeatButton = null;

    private int count = 0;

    private void Awake()
    {
        m_videoPlayer.loopPointReached += OnMovieFinished;
    }

    private void OnDestroy()
    {
        m_videoPlayer.loopPointReached -= OnMovieFinished;
    }

    public void ManageButtons()
    {
        
        if (count < 2)
        {
            repeatButton.SetActive(true);
        }

        startButton.SetActive(true);
        count++;
    }

    void OnMovieFinished(VideoPlayer player)
    {
        if (OnMovieFinishedPlaying != null)
        {
            OnMovieFinishedPlaying.Invoke();
        }
    }
}
