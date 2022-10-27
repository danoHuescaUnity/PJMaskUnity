using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayElement : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private string initializeText = null;

    void Start()
    {
        scoreText.text = initializeText + " 0";
        Player local = PhotonNetwork.LocalPlayer;

        if (local.CustomProperties.TryGetValue("Score", out object score))
        {
            scoreText.text = initializeText + " " + score.ToString();
        }
    }
}
