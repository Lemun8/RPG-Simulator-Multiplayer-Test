using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject playerPrefab;
    public GameObject gameOverScreen;

    PhotonView photonView;
    int kills;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    public void GetKill()
    {
        photonView.RPC(nameof(RPC_GetKill), photonView.Owner);
    }

    [PunRPC]
    void RPC_GetKill()
    {
        kills++;

        Hashtable hash = new Hashtable();
        hash.Add("kills", kills);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    public static PlayerManager Find(Player player)
    {
        PlayerManager[] managers = FindObjectsOfType<PlayerManager>();

        foreach (PlayerManager manager in managers)
        {
            if (manager.photonView.Owner == player)
            {
                return manager;
            }
        }

        return null;
    }
}
