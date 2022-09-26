using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class PlayersList : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject playerListElementPrefab = null;

    [SerializeField]
    private Sprite[] ululettes = null;

    [SerializeField]
    private CanvasGroup backgroundImage = null;

    private Dictionary<Player, PlayerListElement> playerListElements = new Dictionary<Player, PlayerListElement>();
    private int index = 1;
    private int imageIndex = 0;


    private void Start()
    {
        if (GameManager.instance.isManager && backgroundImage != null)
        {
            backgroundImage.alpha = 1.0f;
        }

        foreach (Player player in PhotonNetwork.PlayerList)
        {
            
            if (GameManager.instance.isManager && player == PhotonNetwork.LocalPlayer)
            {
                PhotonNetwork.LocalPlayer.NickName = "Jugador: 0";
            }

            else
            {
                player.NickName = "Jugador: " + index;
                AddElement(player);
                index++;
            }
        }

    }

    private void AddElement(Player player)
    {
        PlayerListElement element = Instantiate(playerListElementPrefab, gameObject.transform).GetComponent<PlayerListElement>();
        element.Initialize(player);
        element.SetImage(ululettes[imageIndex]);
        imageIndex++;
        playerListElements[player] = element;
    }

    private void RemoveElement(Player player)
    {
        Destroy(playerListElements[player].gameObject);
        playerListElements.Remove(player);
        index--;
        imageIndex--;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        newPlayer.NickName = "Jugador: " + index;
        AddElement(newPlayer);
        index++;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RemoveElement(otherPlayer);
    }

}
