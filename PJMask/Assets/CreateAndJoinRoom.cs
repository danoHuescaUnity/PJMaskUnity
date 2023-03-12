using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private string roomName = string.Empty;

    private bool joinRoom = false;

    private void Start()
    {
        joinRoom = false;

#if IS_MANAGER
        if (SceneManager.GetActiveScene().name == "Intro")
        {
            JoinRoom();
        }
#endif
    }

    private void CreateRoom()
    {
        PhotonNetwork.CreateRoom(roomName);
        //JoinRoom();
    }

    public void JoinRoom()
    {
        joinRoom = true;

        if (!PhotonNetwork.InRoom)
            PhotonNetwork.JoinRoom(roomName);
        else
        {
            PhotonNetwork.LoadLevel("ARScene");
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room not found. creating room");
        CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        if (joinRoom)
        {
            PhotonNetwork.LoadLevel("ARScene");

        }
    }

    public override void OnConnectedToMaster()
    {
        if (joinRoom)
        {
            JoinRoom();
        }
    }
}
