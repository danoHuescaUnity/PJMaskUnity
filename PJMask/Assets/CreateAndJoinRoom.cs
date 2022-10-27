using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private string roomName = string.Empty;

    private void CreateRoom()
    {
        PhotonNetwork.CreateRoom(roomName);
        JoinRoom();
    }

    public void JoinRoom()
    {
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
        PhotonNetwork.LoadLevel("ARScene");
    }
}
