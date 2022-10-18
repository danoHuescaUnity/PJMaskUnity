using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        int playersNumber = PhotonNetwork.PlayerList.Length + 1;
        PhotonNetwork.NickName = "Jugador: " + playersNumber.ToString();
        Debug.LogError("PlayerName: " + PhotonNetwork.NickName);
        SceneManager.LoadScene("Intro");
    }
}
