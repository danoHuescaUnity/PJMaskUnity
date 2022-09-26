using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;
    private int score = 0;


    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private int maxScore = 10;

    private void Awake()
    {
        if (instance)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        scoreText.text = "0";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Scored();
        }
    }

    public void Scored()
    {
        score++;
        scoreText.text = "Puntaje : " + score.ToString();
        Hashtable hash = new Hashtable();
        hash.Add("Score", score);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        
        if (score == maxScore)
            GameManager.instance.PhotonLoadScene("Win");
    }

}
