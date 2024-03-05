using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public GameObject endGameUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endGameUI.SetActive(true);
            Pausegame();
        }
    }

    private void Pausegame()
    {
        Time.timeScale = 0f;
    }
}
