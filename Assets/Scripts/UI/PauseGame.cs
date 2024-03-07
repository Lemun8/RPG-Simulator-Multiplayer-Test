using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseGame : MonoBehaviour
{
    public GameObject pausemenu;
    
    public string sceneName;
    public bool toggle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle = !toggle;
            if (toggle == false)
            {
                pausemenu.SetActive(false);
                AudioListener.pause = false;
                Time.timeScale = 1;
               
            }
            if (toggle == true)
            {
                pausemenu.SetActive(true);
                AudioListener.pause = false;
                Time.timeScale = 0;
                
            }
        }
    }
    public void resumeGame()
    {
        toggle = true;
        pausemenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1;
    }
    public void quitToMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(sceneName);
    }
}
