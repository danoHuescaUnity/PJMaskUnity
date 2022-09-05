using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void Scored()
    {
        score++;
        scoreText.text = "Puntaje : " + score.ToString();
        if (score == maxScore)
            GameManager.instance.NextScene();
    }
}
