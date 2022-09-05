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

    private void Awake()
    {
        m_videoPlayer.loopPointReached += OnMovieFinished;
    }

    private void OnDestroy()
    {
        m_videoPlayer.loopPointReached -= OnMovieFinished;
    }

    void OnMovieFinished(VideoPlayer player)
    {
        if (OnMovieFinishedPlaying != null)
        {
            OnMovieFinishedPlaying.Invoke();
        }
    }
}
