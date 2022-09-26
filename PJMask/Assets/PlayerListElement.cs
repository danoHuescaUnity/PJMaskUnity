using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class PlayerListElement : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text playersName = null;

    [SerializeField]
    private Text scoreText = null;

    [SerializeField]
    private Image ululetteImagge = null;

    Player player;

    public void Initialize(Player player)
    {
        this.player = player;

        playersName.text = player.NickName;
        UpdateStats();
    }

    public void SetImage(Sprite pose)
    {
        ululetteImagge.sprite = pose;
    }

    private void UpdateStats()
    {
        if (player.CustomProperties.TryGetValue("Score", out object score))
        {
            scoreText.text = score.ToString();
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (targetPlayer == player)
        {
            if (changedProps.ContainsKey("Score"))
            {
                UpdateStats();
            }
        }
    }
}
