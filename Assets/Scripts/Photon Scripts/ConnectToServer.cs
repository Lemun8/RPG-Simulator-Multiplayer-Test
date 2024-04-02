using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public InputField usernameInput;
    public Text buttonText;
    public Button connectButton; // Reference to the button component

    private bool isConnected = false; // Flag to track connection status

    public void OnClickConnect()
    {
        if (!isConnected && usernameInput.text.Length >= 1)
        {
            isConnected = true; // Set connection flag to true
            PhotonNetwork.NickName = usernameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
            connectButton.interactable = false; // Disable the button
        }
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }
}