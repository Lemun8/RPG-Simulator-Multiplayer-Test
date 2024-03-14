using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject pausemenu;

    private void Update()
    {
        // Check if there are no more enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Replace "Enemy" with your enemy tag

        if (enemies.Length == 0)
        {
            // All enemies are defeated, activate the object
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }

    public void DisconnectAndLoadMainMenu()
    {
        StartCoroutine(DisconnectAndLoad());
        pausemenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator DisconnectAndLoad()
    {
        // Disconnect from the Photon server
        PhotonNetwork.Disconnect();

        // Wait until the disconnection process is completed
        while (PhotonNetwork.NetworkClientState != ClientState.Disconnected)
        {
            yield return null;
        }
    }
}
