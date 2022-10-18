using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;



public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance = null;

    public bool isManager = false;

    [SerializeField]
    private Transform mainCanvas = null;

   
    private void Awake()
    {
        if (instance)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "ARScene")
            return;

        GameObject playerUlulita = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Ululete"), Vector2.zero, Quaternion.identity);
        playerUlulita.transform.parent = mainCanvas;
        RectTransform ululitaRT = playerUlulita.GetComponent<RectTransform>();
        ululitaRT.localPosition = Vector3.zero;
        ululitaRT.anchoredPosition = Vector2.zero;
        ululitaRT.sizeDelta = Vector2.zero;
        ululitaRT.pivot = new Vector2(0.5f, 0.5f);
    }

    public void NextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void PhotonLoadScene(string scene)
    {
        PhotonNetwork.LoadLevel(scene);
    }

    public void ResetScore()
    {
        Hashtable hash = new Hashtable();
        hash.Add("Score", 0);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

}
